﻿using System;

namespace RayTracer
{
    public static class StandardSurfaces
    {
        public static readonly SurfaceTexture CheckerBoard =
            new SurfaceTexture(
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? new Colour(1, 1, 1)
                                    : new Colour(0, 0, 0),
                pos => new Colour(1, 1, 1),
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                150);

        public static readonly SurfaceTexture Shiny =
            new SurfaceTexture(
               pos => new Colour(1, 1, 1),
               pos => new Colour(.5, .5, .5),
               pos => .6,
               50);

        public static readonly SurfaceTexture Matt =
    new SurfaceTexture(
       pos => new Colour(1, 1, 1),
       pos => new Colour(0, 0, 0),
       pos => 0,
       50);
    }
}
