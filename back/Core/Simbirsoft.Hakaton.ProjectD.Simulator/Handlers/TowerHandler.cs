﻿using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public class TowerHandler : Handler
{
    public override void HandleRequest(MapModel request)
    {
        _successor?.HandleRequest(request);
    }
}