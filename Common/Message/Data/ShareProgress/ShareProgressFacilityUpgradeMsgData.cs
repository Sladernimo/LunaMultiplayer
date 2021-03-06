﻿using Lidgren.Network;
using LunaCommon.Message.Base;
using LunaCommon.Message.Types;

namespace LunaCommon.Message.Data.ShareProgress
{
    /// <summary>
    /// Data packet for sending facility upgrades.
    /// </summary>
    public class ShareProgressFacilityUpgradeMsgData : ShareProgressBaseMsgData
    {
        /// <inheritdoc />
        internal ShareProgressFacilityUpgradeMsgData() { }
        public override ShareProgressMessageType ShareProgressMessageType => ShareProgressMessageType.FacilityUpgrade;

        public string FacilityId;
        public int Level;

        public override string ClassName { get; } = nameof(ShareProgressFacilityUpgradeMsgData);

        internal override void InternalSerialize(NetOutgoingMessage lidgrenMsg)
        {
            base.InternalSerialize(lidgrenMsg);
            lidgrenMsg.Write(FacilityId);
            lidgrenMsg.Write(Level);
        }

        internal override void InternalDeserialize(NetIncomingMessage lidgrenMsg)
        {
            base.InternalDeserialize(lidgrenMsg);
            FacilityId = lidgrenMsg.ReadString();
            Level = lidgrenMsg.ReadInt32();
        }

        internal override int InternalGetMessageSize()
        {
            return base.InternalGetMessageSize() + FacilityId.GetByteCount() + sizeof(int);
        }
    }
}
