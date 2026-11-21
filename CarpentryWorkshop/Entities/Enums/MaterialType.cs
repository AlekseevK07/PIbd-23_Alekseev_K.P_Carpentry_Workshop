using System;

namespace WoodworkingWorkshop.Entities.Enums
{
    [Flags]
    public enum MaterialType
    {
        None = 0,
        Wood = 1,
        Metal = 2,
        Glue = 4,
        Varnish = 8
    }
}