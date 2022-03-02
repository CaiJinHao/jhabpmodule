var designerHelper={
    designerCanvas:document.getElementById('designerCanvas'),
    designerInstance:{},
    elementDblClick:function(event){
        console.log(event);
        console.log('form弹窗');
    },
    isConnection:false,
    sourceElement:undefined,
    elementClick:function(event){
        var _the=this;
        console.log(_the);
        if (_the.sourceElement && _the.isConnection) {
            _the.designerInstance.connect({
                source: _the.sourceElement,
                target: event.target,
                connector: 'Flowchart',
                overlays: [
                    {
                        type: "Arrow",
                        options: {
                            location: 1,
                        }
                    }
                ],
            });
            _the.sourceElement = undefined;
            _the.sourceElement = false;
        } else if(_the.isConnection){
            _the.sourceElement = event.target;
        }
    },
    addElement:function(elemnt){
        var _the=this;
        var _e = elemnt.cloneNode(true);
        $(_e).on('dblclick',function(event){_the.elementDblClick(event);});
        $(_e).on('click',function(event){_the.elementClick(event);});
        $(_the.designerCanvas).append(_e);
        _the.designerInstance.batch(function () {
            _the.designerInstance.addEndpoint(_e, {
                source: true,
                target: true,
            });
        });
    },   
    createInstance:function(){
        var _the=this;
        jsPlumbBrowserUI.ready(function () {
            //传入默认值
            _the.designerInstance = jsPlumbBrowserUI.newInstance({
                container: designerHelper.designerCanvas,
                elementsDraggable:true,
                dragOptions: {
                    cursor: 'pointer',
                    zIndex: 2000,
                },
                hoverPaintStyle: {
                    stroke: "red"
                },
                paintStyle: {
                    stroke: 'orange',
                    strokeWidth: 2
                },
                endpointStyle: {
                    stroke: '#ffffff',
                    strokeWidth: 0
                },
                endpointHoverStyle: {
                    fill: "#ffffff"
                },
                endpoint: {
                    type: 'Dot',
                    options: {
                        radius: 6
                    }
                },
                anchor: {
                    type: "Perimeter",
                    options: {
                        shape: "Rectangle",
                        anchorCount: 150
                    }
                },
                dropOptions: {
                    activeClass: "dragActive",
                    hoverClass: "dropHover"
                },
                connection:{
                    connector:'Flowchart'
                }
            });

            _the.designerInstance.bind('connection',function(arg,event){
                console.log('建立连接');
            });
        });
    },
    initEvent:function(){
        var _the = this;
        _the.createInstance();
        $('.steps .step').on('dblclick', function () {
            _the.addElement(this);
        });

        $('.steps .connection').on('click',function(){
            _the.isConnection=!_the.isConnection;
            if(_the.isConnection){
                $(this).addClass('selected');
            }else{
                $(this).removeClass('selected');
                _the.sourceElement=undefined;
            }
        });

        $('#export').on('click',function(){
            _the.designerInstance.exportData();
        });
    }
};

designerHelper.initEvent();