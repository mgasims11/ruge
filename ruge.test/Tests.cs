
namespace Tests
{
    using Xunit;
    using ruge.lib.model;
    using ruge.lib.logic;

    public class Tests
    {
        [Fact]
        public void Test1()  {
            var canvasManager = new CanvasManager();
            var canvas = canvasManager.CreateCanvas(1920,1080);           
            canvasManager.EngineActionEvent += OnEngineActionEvent;
            canvasManager.AddControl(ControlType.Clickable,100,100,30,30,"https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwi21Zv7t6TRAhUJ5SYKHf9VDfQQjRwIBw&url=https%3A%2F%2Fwww.wired.com%2F2015%2F09%2Fgoogles-new-logo-trying-really-hard-look-friendly%2F&bvm=bv.142059868,d.amc&psig=AFQjCNGaCcKVz9eE0w_CnaLV3YrPhAG3aw&ust=1483480043670385","");           
            }

            private void OnEngineActionEvent(object sender, EngineActionEventArgs e) {                
            }
    }
}
