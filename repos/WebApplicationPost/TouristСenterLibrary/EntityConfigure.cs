using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using BMILibrary.Entity;

namespace BMILibrary
{
    public static class EntityConfigure
    {
        public static void BdbmiConfigure(EntityTypeBuilder<Bdbmi> builder)
        {
            builder.HasData(new Bdbmi("Кулдов Григорий Евгеньевич",21,180,73) { ID = 1 });
            builder.HasData(new Bdbmi("Пупкин Василий Семеныч",19,176,200) { ID = 2 });
        }

    }
}
