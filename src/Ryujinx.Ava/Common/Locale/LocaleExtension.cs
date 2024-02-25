<<<<<<< HEAD
using Avalonia.Data.Core;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.MarkupExtensions.CompiledBindings;
=======
﻿using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Ava.Common.Locale
{
    internal class LocaleExtension : MarkupExtension
    {
        public LocaleExtension(LocaleKeys key)
        {
            Key = key;
        }

        public LocaleKeys Key { get; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            LocaleKeys keyToUse = Key;

<<<<<<< HEAD
            var builder = new CompiledBindingPathBuilder();

            builder.SetRawSource(LocaleManager.Instance)
                .Property(new ClrPropertyInfo("Item",
                obj => (LocaleManager.Instance[keyToUse]),
                null,
                typeof(string)), (weakRef, iPropInfo) =>
                {
                    return PropertyInfoAccessorFactory.CreateInpcPropertyAccessor(weakRef, iPropInfo);
                });

            var path = builder.Build();

            var binding = new CompiledBindingExtension(path);
=======
            ReflectionBindingExtension binding = new($"[{keyToUse}]")
            {
                Mode   = BindingMode.OneWay,
                Source = LocaleManager.Instance
            };
>>>>>>> 1ec71635b (sync with main branch)

            return binding.ProvideValue(serviceProvider);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
