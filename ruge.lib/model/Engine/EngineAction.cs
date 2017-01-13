namespace ruge.lib.model.engine { 
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;
    public class EngineAction {
       public EngineActionType ActionType {get;set;}
       public IControl Control {get;set;}
   }
   }