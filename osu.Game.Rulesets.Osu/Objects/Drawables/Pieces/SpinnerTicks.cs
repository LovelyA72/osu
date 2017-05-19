﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Osu.Objects.Drawables.Pieces
{
    public class SpinnerTicks : Container
    {
        private Color4 glowColour;

        public SpinnerTicks()
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            glowColour = colours.BlueDarker.Opacity(0.4f);
            layout();
        }

        private void layout()
        {
            const int count = 18;

            for (int i = 0; i < count; i++)
            {
                Add(new Container
                {
                    Colour = Color4.Black,
                    Alpha = 0.4f,
                    EdgeEffect = new EdgeEffect
                    {
                        Type = EdgeEffectType.Glow,
                        Radius = 20,
                        Colour = glowColour,
                    },
                    RelativePositionAxes = Axes.Both,
                    Masking = true,
                    CornerRadius = 5,
                    Size = new Vector2(60, 10),
                    Origin = Anchor.Centre,
                    Position = new Vector2(
                        0.5f + (float)Math.Sin((float)i / count * 2 * MathHelper.Pi) / 2 * 0.86f,
                        0.5f + (float)Math.Cos((float)i / count * 2 * MathHelper.Pi) / 2 * 0.86f
                    ),
                    Rotation = -(float)i / count * 360 + 90,
                    Children = new[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                        }
                    }
                });
            }
        }
    }
}