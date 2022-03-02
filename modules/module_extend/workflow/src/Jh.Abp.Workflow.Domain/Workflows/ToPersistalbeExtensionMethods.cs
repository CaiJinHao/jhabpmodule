using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public static class ToPersistalbeExtensionMethods
    {
        private static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static WorkflowInstance ToPersistable(this WorkflowCore.Models.WorkflowInstance instance, WorkflowInstance persistable = null)
        {
            if (persistable == null)
                persistable = new WorkflowInstance(new Guid(instance.Id));

            persistable.Data = JsonConvert.SerializeObject(instance.Data, SerializerSettings);
            persistable.Description = instance.Description;
            persistable.Reference = instance.Reference;
            persistable.NextExecution = instance.NextExecution;
            persistable.Version = instance.Version;
            persistable.WorkflowDefinitionId = instance.WorkflowDefinitionId;
            persistable.Status = instance.Status;
            persistable.CompleteTime = instance.CompleteTime;

            foreach (var ep in instance.ExecutionPointers)
            {
                var persistedEP = persistable.ExecutionPointers.Where(a => a.Id == new Guid(ep.Id)).FirstOrDefault();

                if (persistedEP == null)
                {
                    persistedEP = new WorkflowExecutionPointer(new Guid(ep.Id));
                    persistable.ExecutionPointers.Add(persistedEP);
                }

                persistedEP.StepId = ep.StepId;
                persistedEP.Active = ep.Active;
                persistedEP.SleepUntil = ep.SleepUntil;
                persistedEP.PersistenceData = JsonConvert.SerializeObject(ep.PersistenceData, SerializerSettings);
                persistedEP.StartTime = ep.StartTime;
                persistedEP.EndTime = ep.EndTime;
                persistedEP.StepName = ep.StepName;
                persistedEP.RetryCount = ep.RetryCount;
                if (ep.PredecessorId != null)
                {
                    persistedEP.PredecessorId = new Guid(ep.PredecessorId);
                }
                persistedEP.ContextItem = JsonConvert.SerializeObject(ep.ContextItem, SerializerSettings);
                persistedEP.Children = string.Empty;

                foreach (var child in ep.Children)
                    persistedEP.Children += child + ";";

                persistedEP.EventName = ep.EventName;
                persistedEP.EventKey = ep.EventKey;
                persistedEP.EventPublished = ep.EventPublished;
                persistedEP.EventData = JsonConvert.SerializeObject(ep.EventData, SerializerSettings);
                persistedEP.Outcome = JsonConvert.SerializeObject(ep.Outcome, SerializerSettings);
                persistedEP.Status = ep.Status;

                persistedEP.Scope = string.Empty;
                foreach (var item in ep.Scope)
                    persistedEP.Scope += item + ";";

                foreach (var attr in ep.ExtensionAttributes)
                {
                    var persistedAttr = persistedEP.ExtensionAttributes.FirstOrDefault(x => x.AttributeKey == attr.Key);
                    if (persistedAttr == null)
                    {
                        persistedAttr = new WorkflowExtensionAttribute();
                        persistedEP.ExtensionAttributes.Add(persistedAttr);
                    }

                    persistedAttr.AttributeKey = attr.Key;
                    persistedAttr.AttributeValue = JsonConvert.SerializeObject(attr.Value, SerializerSettings);
                }
            }
            return persistable;
        }

        public static WorkflowExecutionError ToPersistable(this ExecutionError instance)
        {
            var result = new WorkflowExecutionError();
            result.Message = instance.Message;
            result.ExecutionPointerId = new Guid(instance.ExecutionPointerId);
            result.WorkflowId = new Guid(instance.WorkflowId);

            return result;
        }

        public static WorkflowEventSubscription ToPersistable(this EventSubscription instance)
        {
            var result = new WorkflowEventSubscription(new Guid(instance.Id));
            result.EventKey = instance.EventKey;
            result.EventName = instance.EventName;
            result.StepId = instance.StepId;
            result.ExecutionPointerId = new Guid(instance.ExecutionPointerId);
            result.WorkflowId = new Guid(instance.WorkflowId);
            result.SubscribeAsOf = instance.SubscribeAsOf.ToLocalTime();//DateTime.SpecifyKind(instance.SubscribeAsOf, DateTimeKind.Utc)
            result.SubscriptionData = JsonConvert.SerializeObject(instance.SubscriptionData, SerializerSettings);
            result.ExternalToken = instance.ExternalToken;
            result.ExternalTokenExpiry = instance.ExternalTokenExpiry;
            result.ExternalWorkerId = instance.ExternalWorkerId;

            return result;
        }

        public static WorkflowEvent ToPersistable(this Event instance)
        {
            var result = new WorkflowEvent(new Guid(instance.Id));
            result.EventKey = instance.EventKey;
            result.EventName = instance.EventName;
            result.IsProcessed = instance.IsProcessed;
            result.EventData = JsonConvert.SerializeObject(instance.EventData, SerializerSettings);
            result.EventTime = instance.EventTime;
            return result;
        }

        public static WorkflowScheduledCommand ToPersistable(this ScheduledCommand instance)
        {
            var result = new WorkflowScheduledCommand();
            result.CommandName = instance.CommandName;
            result.Data = instance.Data;
            result.ExecuteTime = instance.ExecuteTime;

            return result;
        }

        public static WorkflowCore.Models.WorkflowInstance ToWorkflowInstance(this WorkflowInstance instance)
        {
            var result = new WorkflowCore.Models.WorkflowInstance();
            result.Data = JsonConvert.DeserializeObject(instance.Data, SerializerSettings);
            result.Description = instance.Description;
            result.Reference = instance.Reference;
            result.Id = instance.Id.ToString();
            result.NextExecution = instance.NextExecution;
            result.Version = instance.Version;
            result.WorkflowDefinitionId = instance.WorkflowDefinitionId;
            result.Status = instance.Status;
            result.CreateTime = DateTime.SpecifyKind(instance.CreationTime, DateTimeKind.Utc);
            if (instance.CompleteTime.HasValue)
                result.CompleteTime = DateTime.SpecifyKind(instance.CompleteTime.Value, DateTimeKind.Utc);

            result.ExecutionPointers = new ExecutionPointerCollection(instance.ExecutionPointers.Count + 8);

            foreach (var ep in instance.ExecutionPointers.OrderBy(a=>a.StepId))
            {
                var pointer = new ExecutionPointer();

                pointer.Id = ep.Id.ToString();
                pointer.StepId = ep.StepId;
                pointer.Active = ep.Active;

                if (ep.SleepUntil.HasValue)
                    pointer.SleepUntil = DateTime.SpecifyKind(ep.SleepUntil.Value, DateTimeKind.Utc);

                pointer.PersistenceData = JsonConvert.DeserializeObject(ep.PersistenceData ?? string.Empty, SerializerSettings);

                if (ep.StartTime.HasValue)
                    pointer.StartTime = DateTime.SpecifyKind(ep.StartTime.Value, DateTimeKind.Utc);

                if (ep.EndTime.HasValue)
                    pointer.EndTime = DateTime.SpecifyKind(ep.EndTime.Value, DateTimeKind.Utc);

                pointer.StepName = ep.StepName;

                pointer.RetryCount = ep.RetryCount;
                pointer.PredecessorId = ep.PredecessorId?.ToString();
                pointer.ContextItem = JsonConvert.DeserializeObject(ep.ContextItem ?? string.Empty, SerializerSettings);

                if (!string.IsNullOrEmpty(ep.Children))
                    pointer.Children = ep.Children.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                pointer.EventName = ep.EventName;
                pointer.EventKey = ep.EventKey;
                pointer.EventPublished = ep.EventPublished;
                pointer.EventData = JsonConvert.DeserializeObject(ep.EventData ?? string.Empty, SerializerSettings);
                pointer.Outcome = JsonConvert.DeserializeObject(ep.Outcome ?? string.Empty, SerializerSettings);
                pointer.Status = ep.Status;

                if (!string.IsNullOrEmpty(ep.Scope))
                    pointer.Scope = new List<string>(ep.Scope.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

                foreach (var attr in ep.ExtensionAttributes)
                {
                    pointer.ExtensionAttributes[attr.AttributeKey] = JsonConvert.DeserializeObject(attr.AttributeValue, SerializerSettings);
                }

                result.ExecutionPointers.Add(pointer);
            }
            return result;
        }

        public static EventSubscription ToEventSubscription(this WorkflowEventSubscription instance)
        {
            EventSubscription result = new EventSubscription();
            result.Id = instance.Id.ToString();
            result.EventKey = instance.EventKey;
            result.EventName = instance.EventName;
            result.StepId = instance.StepId;
            result.ExecutionPointerId = instance.ExecutionPointerId.ToString();
            result.WorkflowId = instance.WorkflowId.ToString();
            result.SubscribeAsOf = DateTime.SpecifyKind(instance.SubscribeAsOf ?? DateTime.MinValue, DateTimeKind.Utc);
            result.SubscriptionData = JsonConvert.DeserializeObject(instance.SubscriptionData, SerializerSettings);
            result.ExternalToken = instance.ExternalToken;
            result.ExternalTokenExpiry = instance.ExternalTokenExpiry;
            result.ExternalWorkerId = instance.ExternalWorkerId;

            return result;
        }

        public static Event ToEvent(this WorkflowEvent instance)
        {
            Event result = new Event();
            result.Id = instance.Id.ToString();
            result.EventKey = instance.EventKey;
            result.EventName = instance.EventName;
            result.IsProcessed = instance.IsProcessed;
            result.EventData = JsonConvert.DeserializeObject(instance.EventData, SerializerSettings);
            result.EventTime = instance.EventTime;
            return result;
        }

        public static ScheduledCommand ToScheduledCommand(this WorkflowScheduledCommand instance)
        {
            var result = new ScheduledCommand();
            result.CommandName = instance.CommandName;
            result.Data = instance.Data;
            result.ExecuteTime = instance.ExecuteTime;

            return result;
        }
    }
}
