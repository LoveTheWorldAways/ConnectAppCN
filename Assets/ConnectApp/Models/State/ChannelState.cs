using System.Collections.Generic;
using ConnectApp.Models.Model;
using ConnectApp.Models.ViewModel;

namespace ConnectApp.Models.State {
    public class ChannelState {
        public List<string> publicChannels;
        public List<string> joinedChannels;
        public int publicChannelCurrentPage;
        public List<int> publicChannelPages;
        public int publicChannelTotal;
        public bool messageLoading;
        public Dictionary<string, ChannelView> channelDict;
        public Dictionary<string, ChannelMessageView> messageDict;
        public Dictionary<string, ChannelMember> membersDict;
    }
}