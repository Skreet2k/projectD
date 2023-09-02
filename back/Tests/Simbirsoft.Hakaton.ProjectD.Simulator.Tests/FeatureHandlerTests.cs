using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class FeatureHandlerTests
{
    [Fact]
    public void Test1()
    {
        var service = new FeatureHandler();

        var model = new MapModel();

        service.HandleRequest(new MapModel());
        
        Assert.Same(model, model);
    }
}