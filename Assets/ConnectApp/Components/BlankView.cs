using System.Collections.Generic;
using ConnectApp.constants;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace ConnectApp.components {
    public class BlankView : StatelessWidget {
        public BlankView(
            string title,
            Key key = null
        ) : base(key) {
            this.title = title;
        }

        private readonly string title;

        public override Widget build(BuildContext context) {
            var width = MediaQuery.of(context).size.width;
            return new Container(
                color: CColors.White,
                width: width,
                child: new Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: new List<Widget> {
                        new Text(
                            title ?? "",
                            style: CTextStyle.PLargeBody
                        )
                    }
                )
            );
        }
    }
}