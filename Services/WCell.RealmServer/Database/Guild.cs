using System;
using System.Collections.Generic;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using WCell.Constants;
using WCell.Core.Initialization;
using WCell.Util.Threading;
using WCell.RealmServer.Database;
using WCell.RealmServer.Entities;
using WCell.RealmServer.Global;
using WCell.Util.Logging;

namespace WCell.RealmServer.Guilds
{
	[ActiveRecord("Guild", Access = PropertyAccess.Property)]
	public partial class Guild : ActiveRecordBase<Guild>
	{
		private static readonly NHIdGenerator _idGenerator = new NHIdGenerator(typeof(Guild), "_id");

		[PrimaryKey(PrimaryKeyType.Assigned, "Id")]
		private long _id
		{
			get;
			set;
		}

		[Field("Name", NotNull = true, Unique = true)]
		private string _name;

		[Field("MOTD", NotNull = true)]
		private string _MOTD;

		[Field("Info", NotNull = true)]
		private string _info;

		[Field("Created", NotNull = true)]
		private DateTime _created;

		[Field("LeaderLowId", NotNull = true)]
		private int _leaderLowId;

		public uint LeaderLowId
		{
			get { return (uint)_leaderLowId; }
		}

		[Nested("Tabard")]
		private GuildTabard _tabard
		{
			get;
			set;
		}

		[Property]
		public int PurchasedBankTabCount
		{
			get;
			internal set;
		}

		[Property]
		public long Money
		{
			get;
			set;
		}
	}
}