using System;
using System.Collections.Generic;
using ConnectApp.Constants;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;

namespace ConnectApp.Components {
    public class EggButton : StatefulWidget {
        public override State createState() {
            return new _EggButtonState();
        }
    }

    class _EggButtonState : State<EggButton>, TickerProvider {
        AnimationController _controller;
        Animation<float> _animation;
        int _repeat;

        public override void initState() {
            base.initState();

            this._controller = new AnimationController(
                duration: TimeSpan.FromMilliseconds(250),
                vsync: this
            );
            this._animation = new FloatTween(-0.2f, 0.2f).animate(parent: this._controller);
            this._animation.addStatusListener(listener: this._animationStatusListener);
            this._controller.forward();
        }

        public override void dispose() {
            this._animation.removeStatusListener(listener: this._animationStatusListener);
            this._controller.dispose();
            base.dispose();
        }

        public Ticker createTicker(TickerCallback onTick) {
            return new Ticker(onTick: onTick, () => $"created by {this}");
        }

        void _animationStatusListener(AnimationStatus status) {
            if (status == AnimationStatus.completed) {
                this._repeat++;
                this._controller.reverse();
            }

            if (status == AnimationStatus.dismissed) {
                this._repeat++;
                this._controller.forward();
            }

            if (this._repeat >= 8) {
                this._controller.setValue(0.5f);
                this._controller.stop();
            }
        }

        public override Widget build(BuildContext context) {
            return new AnimatedBuilder(
                animation: this._controller,
                builder: (cxt, widget) => new Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    mainAxisSize: MainAxisSize.min,
                    children: new List<Widget> {
                        Transform.rotate(
                            degree: this._animation.value,
                            alignment: Alignment.bottomCenter,
                            child: new Icon(
                                icon: Icons.egg,
                                size: 21,
                                color: CColors.Icon
                            )
                        ),
                        new Container(
                            width: 20,
                            height: 2,
                            decoration: new BoxDecoration(
                                color: CColors.Icon,
                                borderRadius: BorderRadius.all(1)
                            )
                        )
                    }
                )
            );
        }
    }
}