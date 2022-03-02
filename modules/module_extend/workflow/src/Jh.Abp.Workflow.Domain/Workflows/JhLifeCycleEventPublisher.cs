using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models.LifeCycleEvents;

namespace Jh.Abp.Workflow
{
    public class JhLifeCycleEventPublisher : ILifeCycleEventPublisher, IDisposable
    {
        private readonly ILifeCycleEventHub _eventHub;
        private readonly ILogger _logger;
        private BlockingCollection<LifeCycleEvent> _outbox;
        private Task _dispatchTask;

        public JhLifeCycleEventPublisher(ILifeCycleEventHub eventHub, ILoggerFactory loggerFactory)
        {
            _eventHub = eventHub;
            _outbox = new BlockingCollection<LifeCycleEvent>();
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public void PublishNotification(LifeCycleEvent evt)
        {
            if (_outbox.IsAddingCompleted)
                return;

            _outbox.Add(evt);
        }

        public void Start()
        {
            if (_dispatchTask != null)
            {
                throw new InvalidOperationException();
            }

            if (_outbox.IsAddingCompleted)
            {
                _outbox = new BlockingCollection<LifeCycleEvent>();
            }

            _dispatchTask = new Task(Execute);
            _dispatchTask.Start();
        }

        public void Stop()
        {
            _outbox.CompleteAdding();
            _dispatchTask.Wait();
            _dispatchTask = null;
        }

        public void Dispose()
        {
            _outbox.Dispose();
            _outbox = new BlockingCollection<LifeCycleEvent>();//todo:释放之后没有重新创建实例
        }

        private async void Execute()
        {
            foreach (var evt in _outbox.GetConsumingEnumerable())
            {
                try
                {
                    await _eventHub.PublishNotification(evt);
                }
                catch (Exception ex)
                {
                    _logger.LogError(default(EventId), ex, ex.Message);
                }
            }
        }
    }
}
