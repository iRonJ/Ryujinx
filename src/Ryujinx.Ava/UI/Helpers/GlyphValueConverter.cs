<<<<<<< HEAD
=======
using Avalonia.Data;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Controls;
using System;
using System.Collections.Generic;

namespace Ryujinx.Ava.UI.Helpers
{
    public class GlyphValueConverter : MarkupExtension
    {
<<<<<<< HEAD
        private readonly string _key;

        private static readonly Dictionary<Glyph, string> _glyphs = new()
        {
            { Glyph.List, char.ConvertFromUtf32((int)Symbol.List) },
            { Glyph.Grid, char.ConvertFromUtf32((int)Symbol.ViewAll) },
            { Glyph.Chip, char.ConvertFromUtf32(59748) },
=======
        private string _key;

        private static Dictionary<Glyph, string> _glyphs = new Dictionary<Glyph, string>
        {
            { Glyph.List, char.ConvertFromUtf32((int)Symbol.List).ToString() },
            { Glyph.Grid, char.ConvertFromUtf32((int)Symbol.ViewAll).ToString() },
            { Glyph.Chip, char.ConvertFromUtf32(59748).ToString() }
>>>>>>> 1ec71635b (sync with main branch)
        };

        public GlyphValueConverter(string key)
        {
            _key = key;
        }

        public string this[string key]
        {
            get
            {
                if (_glyphs.TryGetValue(Enum.Parse<Glyph>(key), out var val))
                {
                    return val;
                }

                return string.Empty;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
<<<<<<< HEAD
            return this[_key];
        }
    }
}
=======
            Avalonia.Markup.Xaml.MarkupExtensions.ReflectionBindingExtension binding = new($"[{_key}]")
            {
                Mode = BindingMode.OneWay,
                Source = this
            };

            return binding.ProvideValue(serviceProvider);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
