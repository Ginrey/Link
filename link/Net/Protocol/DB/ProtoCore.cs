
      using System;
      using Link.IO;

      namespace Link.Net.Protocol.Core;

      public abstract class Challenge : IDataSerializer
      {
          public Octets Nonce; 
          public uint? Version; 
          public byte? Algo; 
          public Octets Edition; 
          public byte? ExpRate; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KeyExchange : IDataSerializer
      {
          public Octets Nonce; 
          public bool? KickUser; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Response : IDataSerializer
      {
          public Octets Identity; 
          public Octets Key; 
          public bool? UseToken; 
          public Octets CliFingerprint; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class OnlineAnnounce : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public int? RemainTime; 
          public byte? ZoneId; 
          public int? FreeTimeLeft; 
          public int? FreeTimeEnd; 
          public int? CreateTime; 
          public bool? ReferrerFlag; 
          public bool? PasswdFlag; 
          public byte? UsbBind; 
          public bool? AccountinfoFlag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ErrorInfo : IDataSerializer
      {
          public int? ErrCode; 
          public Octets Info; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StatusAnnounce : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public bool? Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusAnnounce : IDataSerializer
      {
          public byte? ZoneId; 
          public int? RoleId; 
          public uint? LocalSid; 
          public bool? Status; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KickoutUser : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public byte? Cause; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GameDataSend : IDataSerializer
      {
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ReportIP : IDataSerializer
      {
          public int? UserID; 
          public int? Ip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UpdateRemainTime : IDataSerializer
      {
          public int? UserID; 
          public int? LocalSid; 
          public int? RemainTime; 
          public int? FreeTimeLeft; 
          public int? FreeTimeEnd; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StatInfoVital : IDataSerializer
      {
          public int? Priority; 
          public Octets Message; 
          public Octets HostName; 
          public Octets ServiceName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StatInfo : IDataSerializer
      {
          public int? Priority; 
          public Octets Message; 
          public Octets HostName; 
          public Octets ServiceName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoteLogVital : IDataSerializer
      {
          public int? Priority; 
          public Octets Message; 
          public Octets HostName; 
          public Octets ServiceName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoteLog : IDataSerializer
      {
          public int? Priority; 
          public Octets Message; 
          public Octets HostName; 
          public Octets ServiceName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerKickout : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerKickout_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerLogin : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public uint? LocalSid; 
          public Octets Auth; 
          public byte? UsbBind; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerLogin_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public int? SrcProviderId; 
          public uint? LocalSid; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerOffline : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerOffline_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerLogout : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public int? ProviderLinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SelectRole : IDataSerializer
      {
          public int? RoleId; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SelectRole_Re : IDataSerializer
      {
          public int? Result; 
          public Octets Auth; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class EnterWorld : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public int? LockTime; 
          public int? Timeout; 
          public int? SetTime; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceProviderID : IDataSerializer
      {
          public int? Id; 
          public float? Left; 
          public float? Right; 
          public float? Top; 
          public float? Bottom; 
          public int? Worldtag; 
          public Octets Edition; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class S2CGamedataSend : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class C2SGamedataSend : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class S2CMulticast : IDataSerializer
      {
          public Octets Data; 
          public Vector<Player> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class S2CBroadcast : IDataSerializer
      {
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PublicChat : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets Message; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatMessage : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? SrcroleId; 
          public Octets Message; 
          public Octets Data; 
          public int? Srclevel; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatMultiCast : IDataSerializer
      {
          public Vector<Player> Playerlist; 
          public byte? Channel; 
          public byte? Emotion; 
          public int? SrcroleId; 
          public Octets Message; 
          public Octets Data; 
          public int? Srclevel; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleList : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public int? Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleList_Re : IDataSerializer
      {
          public int? Result; 
          public int? Handle; 
          public int? UserID; 
          public uint? LocalSid; 
          public Vector<RoleInfo> RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CreateRole : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public RoleInfo RoleInfo; 
          public Octets ReferId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CreateRole_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 
          public RoleInfo RoleInfo; 
          public int? RefretCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DeleteRole : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DeleteRole_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UndoDeleteRole : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UndoDeleteRole_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Keepalive : IDataSerializer
      {
          public byte? Code; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerBaseInfo : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerBaseInfo_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public GRoleBase Player; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerHeartBeat : IDataSerializer
      {
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatSingleCast : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? SrcroleId; 
          public int? DstroleId; 
          public uint? DstlocalSid; 
          public Octets Message; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerStatusSync : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public uint? LocalSid; 
          public int? Status; 
          public int? GSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PrivateChat : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public Octets SrcName; 
          public int? SrcroleId; 
          public Octets DstName; 
          public int? DstroleId; 
          public Octets Message; 
          public Octets Data; 
          public int? Srclevel; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerBaseInfoCRC : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerBaseInfoCRC_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 
          public Vector<int> CRClist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetCustomData : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets CustomData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetCustomData_Re : IDataSerializer
      {
          public int? Result; 
          public uint? CRC; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetUIConfig : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets UiConfig; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetUIConfig_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetUIConfig : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetUIConfig_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets UiConfig; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DisconnectPlayer : IDataSerializer
      {
          public int? RoleId; 
          public int? ProviderLinkId; 
          public uint? LocalSid; 
          public int? GameId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerBriefInfo : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerBriefInfo_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<PlayerBriefInfo> Playerlist; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerStatusAnnounce : IDataSerializer
      {
          public bool? Status; 
          public Vector<OnlinePlayerStatus> PlayerStatusList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryPlayerStatus : IDataSerializer
      {
          public Vector<int> RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetTaskData : IDataSerializer
      {
          public int? TaskId; 
          public int? PlayerId; 
          public Octets Env; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetTaskData_Re : IDataSerializer
      {
          public int? TaskId; 
          public int? PlayerId; 
          public Octets Env; 
          public int? RetCode; 
          public Octets TaskData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetTaskData : IDataSerializer
      {
          public int? TaskId; 
          public Octets TaskData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetTaskData_Re : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetCustomData : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetCustomData_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public uint? CusRoleId; 
          public Octets CustomData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerIdByName : IDataSerializer
      {
          public Octets RoleName; 
          public uint? LocalSid; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerIdByName_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public Octets RoleName; 
          public int? RoleId; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatBroadCast : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? SrcroleId; 
          public Octets Message; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceGM : IDataSerializer
      {
          public int? RoleId; 
          public Octets Auth; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMPrivilegeChange : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceForbidInfo : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public GRoleForbid Forbid; 
          public byte? Disconnect; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FaceModify : IDataSerializer
      {
          public int? RoleId; 
          public int? TicketId; 
          public int? TicketPos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FaceModifyCancel : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FaceModify_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? TicketId; 
          public int? TicketPos; 
          public uint? CRC; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetHelpStates : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets HelpStates; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetHelpStates_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetHelpStates : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetHelpStates_Re : IDataSerializer
      {
          public int? Result; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets HelpStates; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceServerAttribute : IDataSerializer
      {
          public uint? Attr; 
          public int? FreeCreaTime; 
          public byte? ExpRate; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WorldChat : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? RoleId; 
          public Octets Name; 
          public Octets Message; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetChatEmotion : IDataSerializer
      {
          public int? RoleId; 
          public byte? Emotion; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceChallengeAlgo : IDataSerializer
      {
          public byte? ChallengeAlgo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceAuthdVersion : IDataSerializer
      {
          public int? AuVersion; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserCoupon : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserCoupon_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RemainCoupon; 
          public int? TodayExchangeCoupon; 
          public int? TodayRemainCoupon; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserCouponExchange : IDataSerializer
      {
          public int? UserID; 
          public int? CouponNumber; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserCouponExchange_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RemainCoupon; 
          public int? TodayExchangeCoupon; 
          public int? TodayRemainCoupon; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddCashNotify : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountLoginRecord : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public int? LoginTime; 
          public int? Loginip; 
          public int? CurrentIp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserAddCash : IDataSerializer
      {
          public int? UserID; 
          public Octets Cardnum; 
          public Octets CardPasswd; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserAddCash_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SynMutaData : IDataSerializer
      {
          public uint? SynMask; 
          public uint? RoleId; 
          public int? Level; 
          public int? ReincarnationTimes; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SSOGetTicket : IDataSerializer
      {
          public SSOUser User; 
          public int? ToaId; 
          public int? ToZoneId; 
          public Octets Info; 
          public Octets LocalContext; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SSOGetTicket_Re : IDataSerializer
      {
          public int? RetCode; 
          public Octets Ticket; 
          public Octets LocalContext; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPAnnounceDiscount : IDataSerializer
      {
          public int? LocalSid; 
          public Vector<QPDiscountInfo> Discount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPGetActivatedServices : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPGetActivatedServices_Re : IDataSerializer
      {
          public int? LocalSid; 
          public Vector<int> Merchants; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPAddCash : IDataSerializer
      {
          public int? UserID; 
          public int? Cash; 
          public int? CashAfterDiscount; 
          public int? MerchantId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPAddCash_Re : IDataSerializer
      {
          public int? LocalSid; 
          public int? Cash; 
          public int? CashAfterDiscount; 
          public int? MerchantId; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ReportChat : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? DstroleId; 
          public Octets DstRoleName; 
          public Octets Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashMoneyExchangeNotify : IDataSerializer
      {
          public byte? Open; 
          public int? Rate; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerNameUpdate : IDataSerializer
      {
          public int? RoleId; 
          public Octets NewName; 
          public Vector<int> LinkLocalsidList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MobileServerRegister : IDataSerializer
      {
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ServerForbidNotify : IDataSerializer
      {
          public Vector<int> ForbidCtrlList; 
          public Vector<int> ForbidItemList; 
          public Vector<int> ForbidServiceList; 
          public Vector<int> ForbidTaskList; 
          public Vector<int> ForbidSkillList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerAccuse : IDataSerializer
      {
          public int? RoleId; 
          public int? DstroleId; 
          public Octets Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerAccuse_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public int? DstroleId; 
          public int? ReCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ServerTriggerNotify : IDataSerializer
      {
          public Vector<int> TriggerCtrlList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFriend : IDataSerializer
      {
          public int? SrcroleId; 
          public int? DstroleId; 
          public Octets DstName; 
          public uint? SrclSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFriend_Re : IDataSerializer
      {
          public byte? RetCode; 
          public GFriendInfo Info; 
          public uint? SrclSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFriends : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFriends_Re : IDataSerializer
      {
          public int? RoleId; 
          public Vector<GGroupInfo> Groups; 
          public Vector<GFriendInfo> Friends; 
          public Octets Status; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetGroupName : IDataSerializer
      {
          public int? RoleId; 
          public byte? GId; 
          public Octets Name; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetGroupName_Re : IDataSerializer
      {
          public byte? RetCode; 
          public int? RoleId; 
          public byte? GId; 
          public Octets Name; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetFriendGroup : IDataSerializer
      {
          public byte? GId; 
          public int? RoleId; 
          public int? FriendId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetFriendGroup_Re : IDataSerializer
      {
          public byte? RetCode; 
          public byte? GId; 
          public int? RoleId; 
          public int? FriendId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelFriend : IDataSerializer
      {
          public int? RoleId; 
          public int? FriendId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelFriend_Re : IDataSerializer
      {
          public byte? RetCode; 
          public int? RoleId; 
          public int? FriendId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FriendStatus : IDataSerializer
      {
          public int? RoleId; 
          public bool? Status; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetSavedMsg : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetSavedMsg_Re : IDataSerializer
      {
          public byte? RetCode; 
          public Vector<Message> Messages; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomCreate : IDataSerializer
      {
          public int? RoleId; 
          public Octets Subject; 
          public ushort? Capacity; 
          public Octets Password; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomCreate_Re : IDataSerializer
      {
          public short? RetCode; 
          public ushort? RoomId; 
          public Octets Subject; 
          public ushort? Capacity; 
          public bool? Status; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomInvite : IDataSerializer
      {
          public ushort? RoomId; 
          public int? Invitee; 
          public int? Inviter; 
          public Octets Name; 
          public Octets Subject; 
          public ushort? Capacity; 
          public ushort? Number; 
          public Octets Password; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomInvite_Re : IDataSerializer
      {
          public ushort? RoomId; 
          public int? Invitee; 
          public int? Inviter; 
          public short? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomJoin : IDataSerializer
      {
          public ushort? RoomId; 
          public int? OwnerId; 
          public Octets OwnerName; 
          public uint? RoleId; 
          public Octets Password; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomJoin_Re : IDataSerializer
      {
          public short? RetCode; 
          public ushort? RoomId; 
          public int? RoleId; 
          public Octets Name; 
          public GRoomDetail Detail; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomLeave : IDataSerializer
      {
          public ushort? RoomId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomExpel : IDataSerializer
      {
          public ushort? RoomId; 
          public int? RoleId; 
          public int? Owner; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomSpeak : IDataSerializer
      {
          public ushort? RoomId; 
          public byte? Emotion; 
          public Octets Message; 
          public int? Src; 
          public int? Dst; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomList : IDataSerializer
      {
          public ushort? Begin; 
          public byte? Reverse; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChatRoomList_Re : IDataSerializer
      {
          public ushort? Sum; 
          public Vector<GChatRoom> Rooms; 
          public byte? End; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FriendExtList : IDataSerializer
      {
          public int? RoleId; 
          public Vector<GFriendExtInfo> ExtraInfo; 
          public Vector<GSendAUMailRecord> SendInfo; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFriendExtList : IDataSerializer
      {
          public int? RId; 
          public Vector<int> RoleIdList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFriendExtList_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RId; 
          public Vector<GFriendExtInfo> Friendext; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendAUMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? FriendId; 
          public int? MailTemplateId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendAUMail_Re : IDataSerializer
      {
          public int? RoleId; 
          public int? Result; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AUMailSended : IDataSerializer
      {
          public int? RoleId; 
          public int? Level; 
          public byte? ExtReward; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMOnlineNum : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMOnlineNum_Re : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? TotalNum; 
          public int? LocalNum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMListOnlineUser : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? Handler; 
          public Octets Cond; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMListOnlineUser_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? Handler; 
          public Vector<GMPlayerInfo> UserList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMKickoutUser : IDataSerializer
      {
          public int? GmroleId; 
          public int? LocalSid; 
          public int? KickUserId; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMKickoutUser_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public int? LocalSid; 
          public int? KickUserId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMShutup : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? DstUserId; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMShutup_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstUserId; 
          public int? ForbidTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMRestartServer : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? GSId; 
          public int? RestartTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMRestartServer_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? GSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMKickoutRole : IDataSerializer
      {
          public int? GmroleId; 
          public int? LocalSid; 
          public int? KickroleId; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMKickoutRole_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public int? LocalSid; 
          public int? KickroleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMShutupRole : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? DstroleId; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMShutupRole_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstroleId; 
          public int? ForbidTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMToggleChat : IDataSerializer
      {
          public int? GmroleId; 
          public int? LocalSid; 
          public byte? Enable; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMToggleChat_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public int? LocalSid; 
          public byte? Enable; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMForbidRole : IDataSerializer
      {
          public byte? FbdType; 
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? DstroleId; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMForbidRole_Re : IDataSerializer
      {
          public int? RetCode; 
          public byte? FbdType; 
          public int? DstroleId; 
          public int? ForbidTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Report2GM : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets RoleName; 
          public int? ZoneId; 
          public Octets MapZone; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public Octets Content; 
          public int? AId; 
          public Octets Line; 
          public int? ComRoleId; 
          public Octets ComRoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Report2GM_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Complain2GM : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets RoleName; 
          public Octets CompRoleName; 
          public int? ZoneId; 
          public Octets MapZone; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public Octets Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Complain2GM_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceLinkType : IDataSerializer
      {
          public byte? LinkType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetMaxOnlineNum : IDataSerializer
      {
          public int? Maxnum; 
          public int? FakeMaxnum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SetMaxOnlineNum_Re : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMForbidSellPoint : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? ForbidTime; 
          public bool? On; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMForbidSellPoint_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMControlGame : IDataSerializer
      {
          public int? XId; 
          public int? Worldtag; 
          public Octets Command; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMControlGame_Re : IDataSerializer
      {
          public int? XId; 
          public int? RetCode; 
          public Vector<GMControlGameRes> ResVector; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMGetPlayerConsumeInfo : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public Vector<int> Playerlist; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMGetPlayerConsumeInfo_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? GmroleId; 
          public uint? LocalSid; 
          public Vector<PlayerConsumeInfo> Playerlist; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMSetTimelessAutoLock : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public int? DstroleId; 
          public byte? Enable; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMSetTimelessAutoLock_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public int? DstroleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IWebAutolockGet : IDataSerializer
      {
          public int? TId; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IWebAutolockGet_Re : IDataSerializer
      {
          public int? TId; 
          public int? RetCode; 
          public int? UserID; 
          public int? SetTime; 
          public int? LockTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IWebAutolockSet : IDataSerializer
      {
          public int? TId; 
          public int? UserID; 
          public int? LockTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IWebAutolockSet_Re : IDataSerializer
      {
          public int? TId; 
          public int? RetCode; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockCommission : IDataSerializer
      {
          public int? RoleId; 
          public byte? Isbuy; 
          public int? Price; 
          public int? Volume; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockTransaction : IDataSerializer
      {
          public int? RoleId; 
          public byte? WithDraw; 
          public int? Cash; 
          public int? Money; 
          public uint? LocalSid; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockBill : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockBill_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public Vector<StockOrder> Orders; 
          public Vector<StockLog> Logs; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockAccount : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockAccount_Re : IDataSerializer
      {
          public int? Cash; 
          public int? Money; 
          public Vector<StockPrice> Prices; 
          public byte? Locked; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockCommission_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? Cash; 
          public int? Money; 
          public Vector<StockPrice> Prices; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockTransaction_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? Cash; 
          public int? Money; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockCancel : IDataSerializer
      {
          public int? RoleId; 
          public uint? TId; 
          public int? Price; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockCancel_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountingRequest : IDataSerializer
      {
          public uint? Stamp; 
          public int? UserID; 
          public Octets Authenticator; 
          public Vector<AccntParam> Attributes; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountingResponse : IDataSerializer
      {
          public uint? Stamp; 
          public int? UserID; 
          public Octets Authenticator; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceZoneid : IDataSerializer
      {
          public byte? ZoneId; 
          public byte? AId; 
          public bool? reset; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUserPrivilege : IDataSerializer
      {
          public int? UserID; 
          public byte? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUserPrivilege_Re : IDataSerializer
      {
          public int? UserID; 
          public Octets Auth; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUserForbid : IDataSerializer
      {
          public int? UserID; 
          public byte? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUserForbid_Re : IDataSerializer
      {
          public int? UserID; 
          public int? ListType; 
          public Vector<GRoleForbid> Forbid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryRewardType : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryRewardType_Re : IDataSerializer
      {
          public int? RoleId; 
          public int? Reward; 
          public int? Reward2; 
          public int? Param; 
          public int? RewardMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryGameServerAttr : IDataSerializer
      {
          public byte? Paddings; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryGameServerAttr_Re : IDataSerializer
      {
          public Vector<GameAttr> Attr; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddCash : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 
          public int? Sn; 
          public int? Cash; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddCash_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? ZoneId; 
          public int? Sn; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UseCash : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 
          public int? AId; 
          public int? Point; 
          public int? Cash; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UseCash_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class VerifyMaster : IDataSerializer
      {
          public int? ZoneId; 
          public int? RoleId; 
          public Octets RoleName; 
          public Octets Faction; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class VerifyMaster_Re : IDataSerializer
      {
          public Octets RoleName; 
          public int? Ret; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DebugAddCash : IDataSerializer
      {
          public int? UserID; 
          public int? Cash; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceZoneid2 : IDataSerializer
      {
          public int? ZoneId; 
          public int? AId; 
          public bool? reset; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceZoneid3 : IDataSerializer
      {
          public int? ZoneId; 
          public int? AId; 
          public bool? reset; 
          public int? Ip1; 
          public int? Ip2; 
          public int? Ip3; 
          public int? GetAuVersion; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NetBarAnnounce : IDataSerializer
      {
          public int? UserID; 
          public int? AId; 
          public int? ZoneId; 
          public int? Title; 
          public Octets RoleName; 
          public int? NetbarId; 
          public int? NetbarZone; 
          public Octets NetbarName; 
          public int? NetbarLevel; 
          public Octets NetbarTitle; 
          public Octets AwardType; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CertRequest : IDataSerializer
      {
          public int? Reserved1; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CertAnswer : IDataSerializer
      {
          public Octets AuthdCert; 
          public int? Reserved1; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CertKey : IDataSerializer
      {
          public Octets DKey1Encrypt; 
          public Octets DKey2Encrypt; 
          public int? Reserved1; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CertFinish : IDataSerializer
      {
          public int? Reserved1; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixChallenge : IDataSerializer
      {
          public int? Algorithm; 
          public uint? Nonce; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixResponse : IDataSerializer
      {
          public uint? Response; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixFailure : IDataSerializer
      {
          public int? UserID; 
          public int? Loginip; 
          public int? Weight; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddictionControl : IDataSerializer
      {
          public int? ZoneId; 
          public int? UserID; 
          public int? Rate; 
          public int? Message; 
          public Vector<GPair> Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellPoint : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Point; 
          public int? Price; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellPoint_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public SellPointInfo Info; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetSellList : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetSellList_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public Vector<SellPointInfo> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellCancel : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? SellID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellCancel_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public int? SellID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BuyPoint : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? SellID; 
          public int? Seller; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BuyPoint_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public int? SellID; 
          public int? Seller; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SyncSellInfo : IDataSerializer
      {
          public SellPointInfo Info; 
          public int? Buyer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceSellResult : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? SellID; 
          public int? Seller; 
          public int? Point; 
          public int? Price; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TransBuyPoint : IDataSerializer
      {
          public TransID TId; 
          public SellID SellID; 
          public int? Buyer; 
          public int? Price; 
          public int? Point; 
          public int? AId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TransBuyPoint_Re : IDataSerializer
      {
          public int? RetCode; 
          public TransID TId; 
          public SellID SellID; 
          public int? Buyer; 
          public int? Price; 
          public int? Point; 
          public int? AId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FindSellPointInfo : IDataSerializer
      {
          public int? StarTId; 
          public uint? LocalSid; 
          public byte? Forward; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FindSellPointInfo_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public Vector<SellPointInfo> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DomainLogin : IDataSerializer
      {
          public Octets Nonce; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DomainValidate : IDataSerializer
      {
          public Octets Version; 
          public Octets Nonce; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DomainCmd : IDataSerializer
      {
          public Octets Cmd; 
          public Octets Stamp; 
          public int? Length; 
          public byte? Dest; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DomainCmd_Re : IDataSerializer
      {
          public Octets Res; 
          public int? Serial; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutolockSet : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? Timeout; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutolockSet_Re : IDataSerializer
      {
          public int? Result; 
          public int? Timeout; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutolockChanged : IDataSerializer
      {
          public int? RoleId; 
          public int? LockTime; 
          public int? Timeout; 
          public int? SetTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionOpen : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public ushort? Category; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public uint? BasePrice; 
          public uint? BinPrice; 
          public int? ElapseTime; 
          public uint? Deposit; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionOpen_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? AuctionId; 
          public GAuctionItem Info; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionBid : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public uint? BidPrice; 
          public byte? Bin; 
          public uint? LocalSid; 
          public uint? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionBid_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? BidPrice; 
          public uint? AuctionId; 
          public GAuctionItem Info; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionList : IDataSerializer
      {
          public int? RoleId; 
          public ushort? Category; 
          public uint? ItemId; 
          public uint? Begin; 
          public byte? Reverse; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionList_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public ushort? Category; 
          public uint? End; 
          public Vector<GAuctionItem> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionClose : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public byte? Reason; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionClose_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? AuctionId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionGet : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionGet_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? AuctionId; 
          public GAuctionDetail Item; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionAttendList : IDataSerializer
      {
          public int? RoleId; 
          public int? TargetType; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionAttendList_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public int? TargetType; 
          public Vector<GAuctionItem> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionExitBid : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public uint? AuctionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionExitBid_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 
          public uint? AuctionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionGetItem : IDataSerializer
      {
          public int? RoleId; 
          public Vector<uint> Ids; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionGetItem_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public Vector<uint> Ids; 
          public Vector<GRoleInventory> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendAuctionBid : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public uint? BidPrice; 
          public byte? Bin; 
          public uint? LocalSid; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionListUpdate : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<uint> Ids; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionListUpdate_Re : IDataSerializer
      {
          public uint? LocalSid; 
          public Vector<uint> ExpiredIds; 
          public Vector<GAuctionItem> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleGetMap : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleGetMap_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public ushort? MaxbId; 
          public int? Status; 
          public Vector<GTerritory> Cities; 
          public int? BonusId; 
          public int? BonusCount1; 
          public int? BonusCount2; 
          public int? BonusCount3; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleChallenge : IDataSerializer
      {
          public int? RoleId; 
          public short? Id; 
          public uint? FactionId; 
          public uint? Deposit; 
          public int? Authentication; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleChallenge_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public int? RoleId; 
          public short? Id; 
          public uint? Deposit; 
          public uint? Maxbonus; 
          public uint? Challenger; 
          public uint? CutffTime; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleChallengeMap : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleChallengeMap_Re : IDataSerializer
      {
          public int? RoleId; 
          public ushort? RetCode; 
          public int? Status; 
          public uint? Maxbonus; 
          public Vector<GBattleChallenge> Cities; 
          public int? RandNum; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleServerRegister : IDataSerializer
      {
          public int? MapType; 
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleStart : IDataSerializer
      {
          public int? BattleId; 
          public int? MapType; 
          public int? BattleType; 
          public uint? Defender; 
          public uint? Attacker; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleStart_Re : IDataSerializer
      {
          public int? BattleId; 
          public short? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleEnter : IDataSerializer
      {
          public int? RoleId; 
          public int? BattleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleEnter_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleEnterNotice : IDataSerializer
      {
          public ushort? RetCode; 
          public int? RoleId; 
          public int? BattleId; 
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleStatus : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleStatus_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public Octets Cities; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendBattleChallenge : IDataSerializer
      {
          public int? RoleId; 
          public short? Id; 
          public uint? FactionId; 
          public uint? Deposit; 
          public int? Authentication; 
          public uint? LocalSid; 
          public uint? Maxbonus; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleMapNotice : IDataSerializer
      {
          public int? Status; 
          public Vector<GCity> Cities; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DebugCommand : IDataSerializer
      {
          public uint? RoleId; 
          public int? Tag; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleFactionNotice : IDataSerializer
      {
          public Vector<int> FactionIds; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopCreate : IDataSerializer
      {
          public int? RoleId; 
          public int? ShopType; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopCreate_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopBuy : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopBuy_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 
          public PShopItem ItemSell; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSell : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 
          public int? InvPos; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSell_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 
          public int? InvPos; 
          public PShopItem ItemSell; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopCancelGoods : IDataSerializer
      {
          public int? RoleId; 
          public int? CancelType; 
          public int? Pos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopCancelGoods_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? CancelType; 
          public int? Pos; 
          public GRoleInventory ItemStore; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerBuy : IDataSerializer
      {
          public int? RoleId; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public long? MoneyCost; 
          public int? YpCost; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerBuy_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public PShopItem ItemChange; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerSell : IDataSerializer
      {
          public int? RoleId; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 
          public int? InvPos; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerSell_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public PShopItem ItemBuy; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSetType : IDataSerializer
      {
          public int? RoleId; 
          public int? NewType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSetType_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? NewType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopActive : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopActive_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? Status; 
          public int? ExpireTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopManageFund : IDataSerializer
      {
          public int? RoleId; 
          public int? OpType; 
          public uint? Money; 
          public uint? Yinpiao; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopManageFund_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public uint? Money; 
          public uint? Yinpiao; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopDrawItem : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemPos; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopDrawItem_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public int? ItemPos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopClearGoods : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopClearGoods_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public Vector<PShopItem> SList; 
          public Vector<GRoleInventory> Store; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSelfGet : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopSelfGet_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public PShopDetail Detail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerGet : IDataSerializer
      {
          public int? RoleId; 
          public int? Master; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopPlayerGet_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 
          public PShopBase Base; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopList : IDataSerializer
      {
          public int? RoleId; 
          public int? LocalSid; 
          public int? ShopType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopList_Re : IDataSerializer
      {
          public int? LocalSid; 
          public Vector<PShopEntry> ShopList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopListItem : IDataSerializer
      {
          public int? RoleId; 
          public int? LocalSid; 
          public int? ItemId; 
          public byte? ListType; 
          public int? PageNum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopListItem_Re : IDataSerializer
      {
          public int? LocalSid; 
          public Vector<PShopItemEntry> ItemList; 
          public byte? ListType; 
          public int? PageNum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileGetProfileData : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileGetProfileData_Re : IDataSerializer
      {
          public int? RetCode; 
          public PlayerProfileData Data; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileSetProfileData : IDataSerializer
      {
          public int? RoleId; 
          public PlayerProfileData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileGetMatchResult : IDataSerializer
      {
          public int? RoleId; 
          public int? MatchMode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileGetMatchResult_Re : IDataSerializer
      {
          public int? RoleId; 
          public Vector<ProfileMatchResult> Result; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamSetGoal : IDataSerializer
      {
          public int? RoleId; 
          public byte? GoalType; 
          public byte? Op; 
          public int? GoalId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamSetGoal_Re : IDataSerializer
      {
          public int? RoleId; 
          public byte? GoalType; 
          public byte? Op; 
          public int? GoalId; 
          public int? RetCode; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamPlayerReady : IDataSerializer
      {
          public int? RoleId; 
          public int? LeaderId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamPlayerReady_Re : IDataSerializer
      {
          public int? RoleId; 
          public int? LeaderId; 
          public byte? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamComposeStart : IDataSerializer
      {
          public int? GoalId; 
          public int? RoleId; 
          public Vector<int> MemberList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamComposeFailed : IDataSerializer
      {
          public int? RoleId; 
          public int? LeaderId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AutoTeamPlayerLeave : IDataSerializer
      {
          public int? RoleId; 
          public byte? Reason; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TryChangeDS : IDataSerializer
      {
          public int? RoleId; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerChangeDS : IDataSerializer
      {
          public int? RoleId; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerChangeDS_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public bool? Flag; 
          public Octets Random; 
          public int? DstZoneId; 
          public uint? LocalSid; 
          public Octets RoleinfoPack; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ChangeDS_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KeyReestablish : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public bool? Flag; 
          public int? SrcZoneId; 
          public Octets Random; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class LoadExchange : IDataSerializer
      {
          public int? ZoneId; 
          public uint? Version; 
          public Octets Edition; 
          public int? ServerLimit; 
          public int? ServerCount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendDataAndIdentity : IDataSerializer
      {
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public int? SrcZoneId; 
          public int? Ip; 
          public Octets ISeckey; 
          public Octets OSeckey; 
          public Octets Account; 
          public Octets Random; 
          public bool? Flag; 
          public CrossPlayerData Data; 
          public int? DataTimestamp; 
          public int? LoginTime; 
          public byte? AuIsGM; 
          public int? AuFunc; 
          public int? AuFuncparm; 
          public Octets Auth; 
          public byte? UsbBind; 
          public int? RewardMask; 
          public GRoleForbid ForbidTalk; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendDataAndIdentity_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public bool? Flag; 
          public int? DstZoneId; 
          public Octets RoleinfoPack; 
          public byte? IsRemoteRoleidChanged; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DSAnnounceIdentity : IDataSerializer
      {
          public int? ZoneId; 
          public uint? Version; 
          public Octets Edition; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoteLoginQuery : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public bool? Flag; 
          public int? RemoteZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoteLoginQuery_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoteLogout : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KickoutRemoteUser : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KickoutRemoteUser_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRemoteRoleInfo : IDataSerializer
      {
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public int? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRemoteRoleInfo_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public GRoleInfo Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KickoutUser2 : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public int? Cause; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceLinkVersion : IDataSerializer
      {
          public uint? Version; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceCentralDelivery : IDataSerializer
      {
          public byte? IsCentral; 
          public Vector<int> AcceptedZoneList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelRoleAnnounce : IDataSerializer
      {
          public Vector<int> RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerRename : IDataSerializer
      {
          public int? RoleId; 
          public int? AttachObjId; 
          public int? AttachObjNum; 
          public int? AttachObjPos; 
          public Octets NewName; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerRename_Re : IDataSerializer
      {
          public int? LocalSid; 
          public int? RoleId; 
          public Octets NewName; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostPlayerRename : IDataSerializer
      {
          public int? RoleId; 
          public int? ZoneId; 
          public int? RetCode; 
          public Octets NewName; 
          public Octets OldName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerGivePresent : IDataSerializer
      {
          public int? RoleId; 
          public int? TargetRoleId; 
          public int? MailId; 
          public Vector<GRoleInventory> Goods; 
          public uint? CashCost; 
          public byte? HasGift; 
          public int? LogPrice1; 
          public int? LogPrice2; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerGivePresent_Re : IDataSerializer
      {
          public int? LocalSid; 
          public int? RoleId; 
          public uint? CashCost; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerAskForPresent : IDataSerializer
      {
          public int? RoleId; 
          public int? TargetRoleId; 
          public int? GoodsId; 
          public int? GoodsIndex; 
          public int? GoodsSlot; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerAskForPresent_Re : IDataSerializer
      {
          public int? LocalSid; 
          public int? RoleId; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UniqueDataModifyRequire : IDataSerializer
      {
          public int? Worldtag; 
          public int? Key; 
          public int? VType; 
          public Octets Value; 
          public Octets Oldvalue; 
          public bool? Exclusive; 
          public bool? Broadcast; 
          public int? Version; 
          public bool? Timeout; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UniqueDataModifyNotice : IDataSerializer
      {
          public int? Worldtag; 
          public int? Key; 
          public int? VType; 
          public Octets Value; 
          public Octets Oldvalue; 
          public bool? Exclusive; 
          public int? RetCode; 
          public int? Version; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UniqueDataSynch : IDataSerializer
      {
          public byte? Finish; 
          public Vector<GUniqueDataElemNode> Values; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UniqueDataModifyBroadcast : IDataSerializer
      {
          public int? Handle; 
          public Vector<GUniqueDataElemNode> Values; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeStart : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? PartnerRoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeStart_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? PartnerRoleId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeAddGoods : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 
          public GRoleInventory Goods; 
          public uint? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeAddGoods_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? OwnerRoleId; 
          public int? RoleId; 
          public int? LocalSid; 
          public GRoleInventory Goods; 
          public uint? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeRemoveGoods : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 
          public GRoleInventory Goods; 
          public uint? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeRemoveGoods_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? OwnerRoleId; 
          public int? RoleId; 
          public int? LocalSid; 
          public GRoleInventory Goods; 
          public uint? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeMoveObj : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 
          public GRoleInventory Goods; 
          public byte? DstPos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeMoveObj_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? SrcPos; 
          public int? Count; 
          public byte? DstPos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeSubmit : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeSubmit_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? SubmitRoleId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeConfirm : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeConfirm_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? ConfirmRoleId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeDiscard : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeDiscard_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? DiscardRoleId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeEnd : IDataSerializer
      {
          public uint? TId; 
          public byte? Cause; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTradeStart : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId1; 
          public uint? LocalsId1; 
          public int? RoleId2; 
          public uint? LocalsId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTradeStart_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTradeEnd : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId1; 
          public byte? NeedReadDB1; 
          public int? RoleId2; 
          public byte? NeedReadDB2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTradeDiscard : IDataSerializer
      {
          public uint? TId; 
          public byte? Paddings; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class OnDivorce : IDataSerializer
      {
          public int? RId1; 
          public int? RId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPointQuery : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPointQuery_Re : IDataSerializer
      {
          public int? RoleId; 
          public long? Income; 
          public long? Remain; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPointCost : IDataSerializer
      {
          public int? RoleId; 
          public long? OrderId; 
          public uint? Cost; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPointCost_Re : IDataSerializer
      {
          public int? RoleId; 
          public long? OrderId; 
          public uint? Cost; 
          public long? Income; 
          public long? Remain; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuAddupMoneyQuery : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuAddupMoneyQuery_Re : IDataSerializer
      {
          public int? RoleId; 
          public long? AddupMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GiftCodeRedeem : IDataSerializer
      {
          public int? RoleId; 
          public Octets CardNumber; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GiftCodeRedeem_Re : IDataSerializer
      {
          public int? RoleId; 
          public Octets CardNumber; 
          public int? CodeType; 
          public int? ParentType; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SwitchServerStart : IDataSerializer
      {
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 
          public int? SrcGSId; 
          public int? DstGSId; 
          public Octets Key; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SwitchServerCancel : IDataSerializer
      {
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SwitchServerSuccess : IDataSerializer
      {
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 
          public int? DstGSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SwitchServerTimeout : IDataSerializer
      {
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CheckNewMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceNewMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? RemainTime; 
          public byte? PresentType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMailList : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMailList_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<GMailHeader> MailList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMail_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public GMail Mail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMailAttachObj : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 
          public byte? ObjType; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMailAttachObj_Re : IDataSerializer
      {
          public int? RetCode; 
          public byte? MailId; 
          public uint? MoneyLeft; 
          public uint? ItemLeft; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DeleteMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DeleteMail_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreserveMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 
          public bool? Preserve; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreserveMail_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public byte? MailId; 
          public bool? Preserve; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerSendMail : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Receiver; 
          public Octets Title; 
          public Octets Context; 
          public int? AttachObjId; 
          public int? AttachObjNum; 
          public int? AttachObjPos; 
          public uint? AttachMoney; 
          public Octets SenderName; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerSendMail_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Receiver; 
          public int? AttachObjNum; 
          public int? AttachObjPos; 
          public uint? AttachMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysSendMail : IDataSerializer
      {
          public uint? TId; 
          public int? SysId; 
          public byte? SysType; 
          public int? Receiver; 
          public Octets Title; 
          public Octets Context; 
          public GRoleInventory AttachObj; 
          public uint? AttachMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysSendMail_Re : IDataSerializer
      {
          public ushort? RetCode; 
          public uint? TId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailEndSync : IDataSerializer
      {
          public uint? TId; 
          public int? RetCode; 
          public int? RoleId; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerSendMassMail : IDataSerializer
      {
          public byte? MassType; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets Title; 
          public Octets Context; 
          public Octets SenderName; 
          public Vector<int> ReceiverList; 
          public int? CostObjId; 
          public int? CostObjNum; 
          public int? CostObjPos; 
          public uint? CostMoney; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysRecoveredObjMail : IDataSerializer
      {
          public int? TId; 
          public byte? SysType; 
          public int? Receiver; 
          public Octets Title; 
          public Octets Context; 
          public Octets Obj; 
          public Octets Checksum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysRecoveredObjMail_Re : IDataSerializer
      {
          public short? RetCode; 
          public int? TId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashLock : IDataSerializer
      {
          public int? UserID; 
          public Octets CashPassword; 
          public uint? LocalSid; 
          public byte? Lock; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashLock_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashPasswordSet : IDataSerializer
      {
          public int? UserID; 
          public Octets CashPassword; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashPasswordSet_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradePrePost : IDataSerializer
      {
          public int? RoleId; 
          public int? PostType; 
          public uint? Money; 
          public uint? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? Price; 
          public int? SellPeriod; 
          public int? BuyerroleId; 
          public uint? LocalSid; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradePrePost_Re : IDataSerializer
      {
          public int? RetCode; 
          public long? Sn; 
          public GWebTradeItem Info; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradePreCancelPost : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradePreCancelPost_Re : IDataSerializer
      {
          public int? RetCode; 
          public long? Sn; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeList : IDataSerializer
      {
          public int? RoleId; 
          public uint? Category; 
          public uint? Begin; 
          public byte? Reverse; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeList_Re : IDataSerializer
      {
          public uint? Category; 
          public uint? End; 
          public Vector<GWebTradeItem> Items; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeGetItem : IDataSerializer
      {
          public int? RoleId; 
          public Vector<long> Sns; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeGetItem_Re : IDataSerializer
      {
          public Vector<long> Sns; 
          public Vector<GRoleInventory> Items; 
          public Vector<Octets> Rolebriefs; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeAttendList : IDataSerializer
      {
          public int? RoleId; 
          public byte? GetSell; 
          public uint? Begin; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeAttendList_Re : IDataSerializer
      {
          public byte? GetSell; 
          public uint? End; 
          public Vector<GWebTradeItem> Items; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeGetDetail : IDataSerializer
      {
          public int? RoleId; 
          public long? Sn; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeGetDetail_Re : IDataSerializer
      {
          public int? RetCode; 
          public long? Sn; 
          public GWebTradeDetail Detail; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeUpdate : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeUpdate_Re : IDataSerializer
      {
          public int? RetCode; 
          public long? Sn; 
          public GWebTradeItem Item; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeRolePrePost : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public int? Price; 
          public int? SellPeriod; 
          public int? BuyerroleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeRolePreCancelPost : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebTradeRoleGetDetail : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionList : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionList_Re : IDataSerializer
      {
          public Vector<GSysAuctionItem> Items; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionGetItem : IDataSerializer
      {
          public int? RoleId; 
          public Vector<uint> Ids; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionGetItem_Re : IDataSerializer
      {
          public Vector<uint> Ids; 
          public Vector<GRoleInventory> Items; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionAccount : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionAccount_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? Cash; 
          public Vector<uint> BidIds; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionBid : IDataSerializer
      {
          public int? RoleId; 
          public uint? SaId; 
          public uint? BidPrice; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionBid_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? Cash; 
          public GSysAuctionItem Info; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionCashTransfer : IDataSerializer
      {
          public int? RoleId; 
          public byte? WithDraw; 
          public uint? Cash; 
          public uint? LocalSid; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionCashTransfer_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? Cash; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CreateFactionFortress : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 
          public Octets ItemCost; 
          public Octets FortressInfo; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CreateFactionFortress_Re : IDataSerializer
      {
          public int? RetCode; 
          public GFactionFortressBriefInfo Brief; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionServerRegister : IDataSerializer
      {
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NotifyFactionFortressState : IDataSerializer
      {
          public int? FactionId; 
          public int? State; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NotifyFactionFortressInfo2 : IDataSerializer
      {
          public int? FactionId; 
          public GFactionFortressInfo2 Info2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressEnter : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 
          public int? DstFactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressEnterNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? DstFactionId; 
          public int? DstWorldTag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressList : IDataSerializer
      {
          public int? RoleId; 
          public uint? Begin; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressList_Re : IDataSerializer
      {
          public int? Status; 
          public uint? Begin; 
          public Vector<GFactionFortressBriefInfo> List; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressChallenge : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 
          public int? TargetFactionId; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressChallenge_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressBattleList : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressBattleList_Re : IDataSerializer
      {
          public int? Status; 
          public Vector<GFactionFortressBattleInfo> List; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressGet : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionFortressGet_Re : IDataSerializer
      {
          public int? RetCode; 
          public GFactionFortressBriefInfo Brief; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NotifyFactionFortressID : IDataSerializer
      {
          public Vector<int> FactionIds; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NotifyFactionPlayerRename : IDataSerializer
      {
          public int? RoleId; 
          public Octets NewName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerInfoUpdate : IDataSerializer
      {
          public int? RoleId; 
          public int? Level; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerTeamOp : IDataSerializer
      {
          public byte? Operation; 
          public long? TeamUId; 
          public long? Captain; 
          public Vector<int> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerTeamMemberOp : IDataSerializer
      {
          public long? TeamUId; 
          public byte? Operation; 
          public int? Member; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerEnterLeaveGT : IDataSerializer
      {
          public int? RoleId; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SNSRoleBriefUpdate : IDataSerializer
      {
          public int? RoleId; 
          public SNSRoleBrief Brief; 
          public SNSRoleSkills Skills; 
          public SNSRoleEquipment Equipment; 
          public SNSRolePetCorral Petcorral; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionCreate : IDataSerializer
      {
          public Octets FactionName; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets FactionProclaim; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionCreate_Re : IDataSerializer
      {
          public int? RetCode; 
          public Octets FactionName; 
          public uint? FactionId; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionListMember_Re : IDataSerializer
      {
          public int? Handle; 
          public int? RoleId; 
          public uint? LocalSid; 
          public Octets Proclaim; 
          public Vector<FMemberInfo> MemberList; 
          public Vector<int> OnlineList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionApplyJoin_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public uint? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionAcceptJoin_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? NewMember; 
          public int? Operater; 
          public uint? FactionId; 
          public int? Level; 
          public byte? Cls; 
          public Octets Name; 
          public int? Reputation; 
          public byte? ReincarnTimes; 
          public byte? Gender; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionExpel_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public uint? ExpelRoleId; 
          public int? Operater; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionBroadcastNotice_Re : IDataSerializer
      {
          public int? SrcroleId; 
          public int? DstroleId; 
          public uint? DstlocalSid; 
          public Octets Message; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionChangProclaim_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Operater; 
          public Octets Proclaim; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionMasterResign_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? NewMaster; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionAppoint_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? DstroleId; 
          public byte? NewOccup; 
          public int? Operater; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionResign_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? ResignedRole; 
          public byte? OldOccup; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionLeave_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? LeavedRole; 
          public byte? OldOccup; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionUpgrade_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionDegrade_Re : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionDismiss_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionRename_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? RenamedRoleId; 
          public Octets NewName; 
          public int? Operater; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionAllianceApply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionAllianceReply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public byte? Agree; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionHostileApply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionHostileReply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public byte? Agree; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionRemoveRelationApply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public byte? Force; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionRemoveRelationReply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DstFId; 
          public byte? Agree; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionListRelation_Re : IDataSerializer
      {
          public int? LastOpTime; 
          public Vector<GFactionAlliance> Alliance; 
          public Vector<GFactionHostile> Hostile; 
          public Vector<GFactionRelationApply> Apply; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionRelationRecvApply : IDataSerializer
      {
          public int? ApplyType; 
          public int? SrcFId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionRelationRecvReply : IDataSerializer
      {
          public int? PreApplyType; 
          public byte? Agree; 
          public int? SrcFId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionDelayExpelAnnounce : IDataSerializer
      {
          public int? RetCode; 
          public byte? OptType; 
          public int? Operater; 
          public int? ExpelRoleId; 
          public int? Time; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SyncForceGlobalData : IDataSerializer
      {
          public Vector<GForceGlobalDataBrief> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NotifyPlayerJoinOrLeaveForce : IDataSerializer
      {
          public int? ForceId; 
          public byte? IsJoin; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IncreaseForceActivity : IDataSerializer
      {
          public int? ForceId; 
          public int? Activity; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleApply : IDataSerializer
      {
          public Vector<CountryBattleApplyEntry> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleApply_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? CountryId; 
          public int? CountryInvalidTimestamp; 
          public int? CapitalWorldtag; 
          public float? CapitalPosX; 
          public float? CapitalPosY; 
          public float? CapitalPosZ; 
          public Vector<CountryBattleApplyEntry> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleJoinNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? CountryId; 
          public int? Worldtag; 
          public int? MajorStrength; 
          public int? MinorStrength; 
          public byte? IsKing; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleLeaveNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? CountryId; 
          public int? MajorStrength; 
          public int? MinorStrength; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleOnlineNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? CountryId; 
          public int? Worldtag; 
          public int? MinorStrength; 
          public byte? IsKing; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleOfflineNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? CountryId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleEnterMapNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleServerRegister : IDataSerializer
      {
          public int? ServerType; 
          public int? WarType; 
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleConfigNotify : IDataSerializer
      {
          public Vector<GCountryCapital> CountryCapitals; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleMove : IDataSerializer
      {
          public int? RoleId; 
          public int? Dest; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleMove_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? Dest; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleSyncPlayerLocation : IDataSerializer
      {
          public int? RoleId; 
          public int? DomainId; 
          public int? Reason; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleStart : IDataSerializer
      {
          public int? BattleId; 
          public uint? Defender; 
          public uint? Attacker; 
          public uint? PlayerLimit; 
          public int? EndTime; 
          public uint? DefenderPlayerCount; 
          public uint? AttackerPlayerCount; 
          public uint? CountryMaxPlayerCount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleStart_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? BattleId; 
          public int? Worldtag; 
          public uint? Defender; 
          public uint? Attacker; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleEnter : IDataSerializer
      {
          public int? BattleId; 
          public int? Worldtag; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleEnd : IDataSerializer
      {
          public int? BattleId; 
          public int? BattleResult; 
          public int? Attacker; 
          public int? Defender; 
          public Vector<GCountryBattlePersonalScore> AttackerScore; 
          public Vector<GCountryBattlePersonalScore> DefenderScore; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetMap : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetMap_Re : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GCountryBattleDomain> Domains; 
          public Vector<int> Kings; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleSyncPlayerPos : IDataSerializer
      {
          public int? RoleId; 
          public int? Worldtag; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public byte? IsCapital; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetPlayerLocation : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetConfig : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetConfig_Re : IDataSerializer
      {
          public int? StartTimestamp; 
          public int? EndTimetamp; 
          public int? Bonus; 
          public byte? IsBattleOpen; 
          public byte? Domain2DataType; 
          public uint? Domain2DatatTimestamp; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetScore : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetScore_Re : IDataSerializer
      {
          public int? PlayerScore; 
          public Vector<int> CountryScore; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattlePreEnterNotify : IDataSerializer
      {
          public int? BattleId; 
          public int? RoleId; 
          public int? Timeout; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattlePreEnter : IDataSerializer
      {
          public int? BattleId; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleResult : IDataSerializer
      {
          public int? PlayerBonus; 
          public Vector<int> CountryBonus; 
          public Vector<int> CountryDomainsCount; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleReturnCapital : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleSingleBattleResult : IDataSerializer
      {
          public int? DomainId; 
          public int? SingleBattleTotalScore; 
          public int? PlayerSingleBattleScore; 
          public int? PlayerRank; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleKingAssignAssault : IDataSerializer
      {
          public int? KingRoleId; 
          public int? DomainId; 
          public byte? AssaultType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleKingAssignAssault_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DomainId; 
          public byte? AssaultType; 
          public int? CommandPoint; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleKingResetBattleLimit : IDataSerializer
      {
          public int? KingRoleId; 
          public int? DomainId; 
          public byte? Op; 
          public Vector<GCountryBattleLimit> Limit; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetBattleLimit : IDataSerializer
      {
          public int? RoleId; 
          public int? DomainId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetBattleLimit_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? DomainId; 
          public Vector<GCountryBattleLimit> Limit; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetKingCommandPoint : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleGetKingCommandPoint_Re : IDataSerializer
      {
          public int? CommandPoint; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetCNetServerConfig : IDataSerializer
      {
          public int? RoleId; 
          public Vector<int> Keys; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRemoteCNetServerConfig : IDataSerializer
      {
          public Vector<int> Keys; 
          public uint? LinkSId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleDestroyInstance : IDataSerializer
      {
          public int? DomainId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerFactionInfo : IDataSerializer
      {
          public Vector<int> RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerFactionInfo_Re : IDataSerializer
      {
          public int? RetCode; 
          public Vector<PFactionInfo> FactionInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionChat : IDataSerializer
      {
          public byte? Channel; 
          public byte? Emotion; 
          public int? SrcroleId; 
          public Octets Message; 
          public Octets Data; 
          public uint? DstlocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionOPRequest : IDataSerializer
      {
          public int? OpType; 
          public int? RoleId; 
          public Octets Params; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionOPRequest_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? OpType; 
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionBeginSync : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionBeginSync_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? TId; 
          public int? RoleId; 
          public FactionOPSyncInfo SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionEndSync : IDataSerializer
      {
          public uint? TId; 
          public int? RoleId; 
          public FactionOPSyncInfo SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionAcceptJoin : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public uint? FactionId; 
          public int? InvitedRoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFactionBaseInfo : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public Vector<int> FactionList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFactionBaseInfo_Re : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public GFactionBaseInfo FactionInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerFactionInfo : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerFactionInfo_Re : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public GUserFaction FactionInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelFactionAnnounce : IDataSerializer
      {
          public uint? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionListOnline : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionListOnline_Re : IDataSerializer
      {
          public Vector<uint> FidList; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerFactionRelation : IDataSerializer
      {
          public int? FactionId; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetPlayerFactionRelation_Re : IDataSerializer
      {
          public int? FactionId; 
          public Vector<int> RoleIdList; 
          public Vector<int> Alliance; 
          public Vector<int> Hostile; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionCongregateRequest : IDataSerializer
      {
          public int? FactionId; 
          public int? Sponsor; 
          public Octets Data; 
          public Vector<int> Member; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEGetStatus : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEGetStatus_Re : IDataSerializer
      {
          public int? Status; 
          public KEKing King; 
          public Vector<KECandidate> CandidateList; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KECandidateApply : IDataSerializer
      {
          public int? RoleId; 
          public uint? ItemId; 
          public int? ItemNumber; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KECandidateApply_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEVoting : IDataSerializer
      {
          public int? RoleId; 
          public uint? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? CandidateRoleId; 
          public Octets SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEVoting_Re : IDataSerializer
      {
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEKingNotify : IDataSerializer
      {
          public int? RoleId; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattleServerRegister : IDataSerializer
      {
          public int? ServerId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerApply : IDataSerializer
      {
          public int? RoleId; 
          public int? Model; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerApply_Re : IDataSerializer
      {
          public int? RoleId; 
          public int? RetCode; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattleEnter : IDataSerializer
      {
          public int? RoleId; 
          public int? BattleId; 
          public int? Worldtag; 
          public int? Model; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerEnter : IDataSerializer
      {
          public int? RoleId; 
          public int? BattleId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerLeave : IDataSerializer
      {
          public int? RoleId; 
          public int? BattleId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattleStart : IDataSerializer
      {
          public int? BattleId; 
          public int? EndTime; 
          public uint? MaxPlayerCount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattleStart_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? BattleId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattleEnd : IDataSerializer
      {
          public int? BattleId; 
          public int? Worldtag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerScoreUpdate : IDataSerializer
      {
          public int? BattleId; 
          public int? Worldtag; 
          public Vector<TankBattlePlayerScoreInfo> PlayerScores; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerGetRank : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerGetRank_Re : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? RetCode; 
          public TankBattlePlayerScoreInfo YourScore; 
          public Vector<TankBattlePlayerScoreInfo> PlayerScores; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendRefAddBonus : IDataSerializer
      {
          public int? RoleId; 
          public int? Bonus; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendRefCashUsed : IDataSerializer
      {
          public int? RoleId; 
          public int? CashUsed; 
          public int? Level; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefListReferrals : IDataSerializer
      {
          public int? RoleId; 
          public int? StartIndex; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefListReferrals_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? StartIndex; 
          public int? Total; 
          public int? BonusAvailToday; 
          public Vector<ReferralBrief> Referrals; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefWithdrawBonus : IDataSerializer
      {
          public int? RoleId; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefWithdrawBonus_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefGetReferenceCode : IDataSerializer
      {
          public int? RoleId; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RefGetReferenceCode_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? Level; 
          public int? Reputation; 
          public Octets RefCode; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendRewardAddBonus : IDataSerializer
      {
          public int? RoleId; 
          public int? Bonus; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRewardList : IDataSerializer
      {
          public int? RoleId; 
          public int? StartIndex; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRewardList_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? ConsumePoints; 
          public int? StartIndex; 
          public int? Total; 
          public Vector<RewardItem> RewardList; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ExchangeConsumePoints : IDataSerializer
      {
          public int? RoleId; 
          public int? RewardType; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ExchangeConsumePoints_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public int? BonusAdd; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RewardMatureNotice : IDataSerializer
      {
          public int? RoleId; 
          public int? BonusReward; 
          public int? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SendTaskReward : IDataSerializer
      {
          public int? RoleId; 
          public int? BonusAdd; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Acreport : IDataSerializer
      {
          public int? RoleId; 
          public Octets Report; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACWhoAmI : IDataSerializer
      {
          public int? ClientType; 
          public int? SubId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACRemoteCode : IDataSerializer
      {
          public int? DstroleId; 
          public Vector<Octets> Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACConnectRe : IDataSerializer
      {
          public int? AId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACReloadConfig : IDataSerializer
      {
          public int? ReloadType; 
          public Octets Config; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACReloadConfigRe : IDataSerializer
      {
          public int? ResCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQLogInfo : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACLogInfo> Logs; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQUserOnline : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<IntData> Users; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACSendCode : IDataSerializer
      {
          public int? RoleId; 
          public Octets CodeName; 
          public Octets Param; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQCodeRes : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACUserCodeRes> Res; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQPatterns : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACStackPattern> Patterns; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQPlatformInfo : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACPlatformInfo> PlatformInfo; 
          public Vector<ACCPUInfo> CpuInfo; 
          public Vector<ACMemInfo> MemInfo; 
          public Vector<ACAdapterInfo> AdapterInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACVersion : IDataSerializer
      {
          public Octets Version; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQStrOwner : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<IntData> Owners; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQMouseInfo : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACMouseInfo> MouseInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQThreadTimes : IDataSerializer
      {
          public ACQ ACQ; 
          public ACThreadTime ProcessTime; 
          public Vector<ACThreadTime> ThreadTimes; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACProtoStat : IDataSerializer
      {
          public int? RoleId; 
          public int? Keepalive; 
          public int? GameDataSend; 
          public int? PublicChat; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQProtocolStats : IDataSerializer
      {
          public ACQ ACQ; 
          public Vector<ACProtocolStat> ProtoStats; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACStatusAnnounce : IDataSerializer
      {
          public int? Status; 
          public Vector<ACOnlineStatus> InfoList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACRemoteExe : IDataSerializer
      {
          public int? FileSize; 
          public int? RoleId; 
          public int? PType; 
          public Octets Exe; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACRemoteExeRe : IDataSerializer
      {
          public int? ResCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACReportCheater : IDataSerializer
      {
          public int? RoleId; 
          public int? CheatType; 
          public Octets CheatInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACTriggerQuestion : IDataSerializer
      {
          public int? RoleId; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQuestion : IDataSerializer
      {
          public int? RoleId; 
          public int? QType; 
          public int? Seq; 
          public int? Reserved; 
          public Vector<Octets> Question; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACAnswer : IDataSerializer
      {
          public int? RoleId; 
          public int? QType; 
          public int? Seq; 
          public int? Reserved; 
          public int? Answer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACStatusAnnounce2 : IDataSerializer
      {
          public int? Status; 
          public Vector<ACOnlineStatus2> InfoList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACKickoutUser : IDataSerializer
      {
          public int? GmUserId; 
          public int? IdType; 
          public int? UserID; 
          public int? ForbidTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACAccuse : IDataSerializer
      {
          public int? ZoneId; 
          public long? RoleId; 
          public long? AccId; 
          public long? AccusationRoleId; 
          public long? AccusationAccId; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACAccuseRe : IDataSerializer
      {
          public int? ZoneId; 
          public long? RoleId; 
          public long? AccId; 
          public long? AccusationRoleId; 
          public long? AccusationAccId; 
          public int? Result; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ForwardChat : IDataSerializer
      {
          public int? ZoneId; 
          public int? LineId; 
          public int? UserID; 
          public int? RoleId; 
          public Octets Name; 
          public Octets Message; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DisableAutolock : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACForbidCheater : IDataSerializer
      {
          public int? UserID; 
          public int? Time; 
          public byte? Operation; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuthdVersion : IDataSerializer
      {
          public int? Version; 
          public int? RetCode; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SSOGetTicketReq : IDataSerializer
      {
          public SSOUser User; 
          public int? Loginip; 
          public int? ToaId; 
          public int? ToZoneId; 
          public Octets Info; 
          public Octets LocalContext; 
          public Octets Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SSOGetTicketRep : IDataSerializer
      {
          public int? RetCode; 
          public SSOUser User; 
          public Octets Ticket; 
          public Octets LocalContext; 
          public Octets Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Post : IDataSerializer
      {
          public int? AId; 
          public int? ZoneId; 
          public TraderInfo Seller; 
          public TraderInfo Buyer; 
          public long? Sn; 
          public int? Price; 
          public byte? Shelf; 
          public int? PostType; 
          public int? Num; 
          public int? Loginip; 
          public TimeInfo Time; 
          public PostInfo Info; 
          public Octets Backup; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Post_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public TimeInfo Time; 
          public int? RetCode; 
          public long? Timestamp; 
          public int? BuyLevel; 
          public int? CommodityId; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GamePostCancel : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GamePostCancel_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebPostCancel : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? CType; 
          public long? MessageId; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebPostCancel_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? MessageId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Shelf : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? Price; 
          public TimeInfo Time; 
          public long? BuyerroleId; 
          public long? MessageId; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Shelf_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? MessageId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ShelfCancel : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public long? MessageId; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ShelfCancel_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? MessageId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Sold : IDataSerializer
      {
          public int? ZoneId; 
          public int? SellerUserId; 
          public long? SellerroleId; 
          public int? BuyerUserId; 
          public long? BuyerroleId; 
          public long? Sn; 
          public long? OrderId; 
          public int? SType; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Sold_Re : IDataSerializer
      {
          public int? ZoneId; 
          public int? SellerUserId; 
          public long? SellerroleId; 
          public int? BuyerUserId; 
          public long? BuyerroleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? OrderId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostExpire : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public long? MessageId; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostExpire_Re : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public long? Sn; 
          public int? RetCode; 
          public long? MessageId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebGetRoleList : IDataSerializer
      {
          public int? UserID; 
          public long? MessageId; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebGetRoleList_Re : IDataSerializer
      {
          public int? AId; 
          public int? UserID; 
          public int? RetCode; 
          public Vector<WebRole> RoleList; 
          public long? MessageId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class NewKeepAlive : IDataSerializer
      {
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AU2Game : IDataSerializer
      {
          public int? UserID; 
          public int? QType; 
          public Octets Info; 
          public int? RetCode; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Game2AU : IDataSerializer
      {
          public int? UserID; 
          public int? QType; 
          public Octets Info; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingBalanceSA : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingBalanceSA_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? Cashremain; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingConfirm : IDataSerializer
      {
          public int? UserID; 
          public int? ItemId; 
          public int? ItemCount; 
          public Octets ItemName; 
          public int? ItemExpire; 
          public int? ItemPrice; 
          public int? Loginip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingConfirm_Re : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? ItemId; 
          public int? ItemCount; 
          public Octets ItemName; 
          public int? ItemExpire; 
          public int? ItemPrice; 
          public int? Cashremain; 
          public Octets Chargeno; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingCancel : IDataSerializer
      {
          public int? UserID; 
          public Octets Chargeno; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DiscountAnnounce : IDataSerializer
      {
          public Vector<MerchantDiscount> Discount; 
          public int? Reserved1; 
          public Octets Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysSendMail3 : IDataSerializer
      {
          public long? OrderId; 
          public int? UserID; 
          public long? RoleId; 
          public Octets RoleName; 
          public Octets MailTitle; 
          public Octets MailContext; 
          public uint? AttachMoney; 
          public MailGoodsInventory AttachGoods; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysSendMail3_Re : IDataSerializer
      {
          public long? OrderId; 
          public int? RetCode; 
          public long? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceZoneidToIM : IDataSerializer
      {
          public int? AId; 
          public int? ZoneId; 
          public long? BootTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GameSysMsg : IDataSerializer
      {
          public int? MType; 
          public long? Time; 
          public int? EmotionGroup; 
          public Octets Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GameDataReq : IDataSerializer
      {
          public int? DType; 
          public long? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GameDataResp : IDataSerializer
      {
          public int? DType; 
          public long? Id; 
          public byte? RetCode; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IMKeepAlive : IDataSerializer
      {
          public byte? Code; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceResp : IDataSerializer
      {
          public int? Code; 
          public long? BootTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleListReq : IDataSerializer
      {
          public long? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleRelationReq : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleRelationResp : IDataSerializer
      {
          public long? UserID; 
          public RoleBean RoleInfo; 
          public Vector<FactionIDBean> Factions; 
          public Vector<RoleGroupBean> Friends; 
          public Vector<RoleInfoBean> BlackList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusReq : IDataSerializer
      {
          public long? LocalRId; 
          public Vector<long> RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusUpdate : IDataSerializer
      {
          public long? RoleId; 
          public RoleStatusBean Status; 
          public Vector<long> Friends; 
          public Vector<FactionIDBean> Factions; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleGroupUpdate : IDataSerializer
      {
          public long? RoleId; 
          public int? GType; 
          public long? GroupId; 
          public Octets GroupName; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleFriendUpdate : IDataSerializer
      {
          public long? RoleId; 
          public RoleBean Rolefriend; 
          public int? GType; 
          public long? GroupId; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleBlacklistUpdate : IDataSerializer
      {
          public long? RoleId; 
          public RoleInfoBean Target; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleMsg : IDataSerializer
      {
          public long? Receiver; 
          public RoleMsgBean Message; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleOfflineMessages : IDataSerializer
      {
          public long? Receiver; 
          public Vector<RoleMsgBean> Messages; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleActivation : IDataSerializer
      {
          public long? RoleId; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoveRole : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfoUpdate : IDataSerializer
      {
          public RoleInfoBean RoleInfo; 
          public int? UpdateFlag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfoReq : IDataSerializer
      {
          public long? LocalUId; 
          public long? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfoResp : IDataSerializer
      {
          public long? LocalUId; 
          public RoleInfoBean RoleInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SyncTeams : IDataSerializer
      {
          public Vector<TeamBean> Teams; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TeamCreate : IDataSerializer
      {
          public TeamBean Team; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TeamDismiss : IDataSerializer
      {
          public long? TeamId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TeamMemberUpdate : IDataSerializer
      {
          public long? TeamId; 
          public Vector<long> Members; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInfoReq : IDataSerializer
      {
          public long? LocalUId; 
          public FactionIDBean FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInfoResp : IDataSerializer
      {
          public long? LocalUId; 
          public FactionIDBean FactionId; 
          public FactionInfoBean FactionInfo; 
          public Vector<FactionTitleBean> Members; 
          public Octets ForbidList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionMemberUpdate : IDataSerializer
      {
          public FactionIDBean FactionId; 
          public Vector<RoleBean> Roles; 
          public int? TitleId; 
          public byte? Operation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInfoUpdate : IDataSerializer
      {
          public FactionIDBean FactionId; 
          public FactionInfoBean FactionInfo; 
          public int? UpdateFlag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionMsg : IDataSerializer
      {
          public FactionIDBean FactionId; 
          public RoleMsgBean Message; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RemoveFaction : IDataSerializer
      {
          public FactionIDBean FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionForbidUpdate : IDataSerializer
      {
          public FactionIDBean FactionId; 
          public Octets UpdateForbid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleEnterVoiceChannel : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 
          public int? ZoneId; 
          public long? Seq; 
          public long? Timestamp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleLeaveVoiceChannel : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 
          public int? ZoneId; 
          public long? Seq; 
          public long? Timestamp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleEnterVoiceChannelAck : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 
          public int? ZoneId; 
          public long? Seq; 
          public long? Timestamp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleLeaveVoiceChannelAck : IDataSerializer
      {
          public long? UserID; 
          public long? RoleId; 
          public int? ZoneId; 
          public long? Seq; 
          public long? Timestamp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingBalance : IDataSerializer
      {
          public int? UserID; 
          public int? Request; 
          public int? Result; 
          public int? Balance; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BillingRequest : IDataSerializer
      {
          public int? UserID; 
          public int? Request; 
          public int? Result; 
          public int? ItemId; 
          public int? ItemNumber; 
          public int? Timeout; 
          public int? Amount; 
          public Octets MenuId; 
          public Octets Bxtxno; 
          public Octets Agtxno; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Integer : IDataSerializer
      {
          public int? Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLoginArg : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public bool? KickUser; 
          public int? FreeCreaTime; 
          public int? Loginip; 
          public Octets Account; 
          public Octets ISeckey; 
          public Octets OSeckey; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLoginRes : IDataSerializer
      {
          public byte? RetCode; 
          public int? RemainPlayTime; 
          public int? Func; 
          public int? Funcparm; 
          public bool? IsGM; 
          public int? FreeTimeLeft; 
          public int? FreeTimeEnd; 
          public int? CreateTime; 
          public int? AddUpPoint; 
          public int? SoldPoint; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLogoutArg : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLogoutRes : IDataSerializer
      {
          public byte? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Player : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfo : IDataSerializer
      {
          public int? RoleId; 
          public byte? Gender; 
          public byte? Race; 
          public byte? Occupation; 
          public int? Level; 
          public int? Level2; 
          public Octets Name; 
          public Octets CustomData; 
          public Vector<GRoleInventory> Equipment; 
          public bool? Status; 
          public int? DeleteTime; 
          public int? CreateTime; 
          public int? LastloginTime; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public int? Worldtag; 
          public Octets CustomStatus; 
          public Octets CharacterMode; 
          public int? ReferrerRole; 
          public int? CashAdd; 
          public Octets ReincarnationData; 
          public Octets RealmData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerBriefInfo : IDataSerializer
      {
          public int? RoleId; 
          public byte? Occupation; 
          public Octets Name; 
          public byte? Gender; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class OnlinePlayerStatus : IDataSerializer
      {
          public int? RoleId; 
          public int? GId; 
          public int? LinkId; 
          public uint? LinkSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetTaskDataArg : IDataSerializer
      {
          public int? TaskId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetTaskDataRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets TaskData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutTaskDataArg : IDataSerializer
      {
          public int? TaskId; 
          public Octets TaskData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutTaskDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMQueryRoleInfoRes : IDataSerializer
      {
          public int? Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUseridArg : IDataSerializer
      {
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QueryUseridRes : IDataSerializer
      {
          public int? Result; 
          public int? UserID; 
          public int? RoleId; 
          public int? Level; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPDiscountLevel : IDataSerializer
      {
          public int? AmountBegin; 
          public int? Discount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class QPDiscountInfo : IDataSerializer
      {
          public int? Id; 
          public Octets Name; 
          public Vector<QPDiscountLevel> Discount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerPositionResetRqstArg : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Worldtag; 
          public int? Reason; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerPositionResetRqstRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashMoneyExchangeControlArg : IDataSerializer
      {
          public byte? Oper; 
          public int? Param; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashMoneyExchangeControlRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ServerForbidControlArg : IDataSerializer
      {
          public byte? Oper; 
          public Octets Param; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ServerForbidControlRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets ForbidCmd; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMPlayerInfo : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public int? LinkId; 
          public uint? LocalSid; 
          public int? GSId; 
          public bool? Status; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMaxOnlineNumArg : IDataSerializer
      {
          public int? Padding; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMaxOnlineNumRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Maxnum; 
          public int? FakeMaxnum; 
          public int? Curnum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMGetGameAttriArg : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public byte? Attribute; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMGetGameAttriRes : IDataSerializer
      {
          public Octets Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMSetGameAttriArg : IDataSerializer
      {
          public int? GmroleId; 
          public uint? LocalSid; 
          public byte? Attribute; 
          public Octets Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMSetGameAttriRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMControlGameRes : IDataSerializer
      {
          public int? GSId; 
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerConsumeInfo : IDataSerializer
      {
          public int? RoleId; 
          public int? Level; 
          public int? Loginip; 
          public uint? CashAdd; 
          public uint? MallConsumption; 
          public uint? AvgOnlineTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetConsumeInfosArg : IDataSerializer
      {
          public Vector<int> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetConsumeInfosRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<PlayerConsumeInfo> Playerlist; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAutolockSetOfflineArg : IDataSerializer
      {
          public int? UserID; 
          public Vector<GPair> AutoLockDiff; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAutolockSetOfflineRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GPair> AutoLock; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAutolockGetArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAutolockGetRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GPair> AutoLock; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GQueryPasswdArg : IDataSerializer
      {
          public Octets Account; 
          public Octets Challenge; 
          public int? Loginip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GQueryPasswdRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public Octets Response; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccntParam : IDataSerializer
      {
          public uint? Type; 
          public uint? Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GameAttr : IDataSerializer
      {
          public byte? Attr; 
          public Octets Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashSerialArg : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 
          public byte? Force; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CashSerialRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? ZoneId; 
          public int? Sn; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetAddCashSNArg : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetAddCashSNRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? ZoneId; 
          public int? Sn; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixPasswdArg : IDataSerializer
      {
          public Octets Account; 
          public Octets Challenge; 
          public int? Loginip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixPasswdRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? Algorithm; 
          public Octets Response; 
          public Octets Matrix; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GPair : IDataSerializer
      {
          public int? Key; 
          public int? Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetUserCouponArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetUserCouponRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RemainCoupon; 
          public int? TodayExchangeCoupon; 
          public int? TodayRemainCoupon; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CouponExchangeArg : IDataSerializer
      {
          public int? UserID; 
          public int? CouponNumber; 
          public int? CashNumber; 
          public long? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CouponExchangeRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RemainCoupon; 
          public int? TodayExchangeCoupon; 
          public int? TodayRemainCoupon; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixPasswd2Res : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? Algorithm; 
          public Octets Response; 
          public Octets Matrix; 
          public Octets Seed; 
          public Octets Pin; 
          public int? RTime; 
          public int? AuCurTime; 
          public Vector<GRoleForbid> Forbid; 
          public Octets LastUsedElecNumber; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLogin2Arg : IDataSerializer
      {
          public int? UserID; 
          public uint? LocalSid; 
          public bool? KickUser; 
          public int? FreeCreaTime; 
          public Octets UsedElecNumber; 
          public int? Reserved1; 
          public Octets Reserved2; 
          public int? Loginip; 
          public Octets Account; 
          public Octets ISeckey; 
          public Octets OSeckey; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserLogin2Res : IDataSerializer
      {
          public int? RetCode; 
          public int? RemainPlayTime; 
          public int? Func; 
          public int? Funcparm; 
          public bool? IsGM; 
          public int? FreeTimeLeft; 
          public int? FreeTimeEnd; 
          public int? CreateTime; 
          public int? AddUpPoint; 
          public int? SoldPoint; 
          public Octets Auth; 
          public byte? Gender; 
          public int? RemainCoupon; 
          public int? TodayExchangeCoupon; 
          public int? TodayRemainCoupon; 
          public Octets NickName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixTokenArg : IDataSerializer
      {
          public Octets Account; 
          public Octets Token; 
          public int? Loginip; 
          public Octets Challenge; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MatrixTokenRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public int? Algorithm; 
          public Octets Response; 
          public Octets Matrix; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class InstantAddCashArg : IDataSerializer
      {
          public int? UserID; 
          public int? Loginip; 
          public Octets Cardnum; 
          public Octets CardPasswd; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class InstantAddCashRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SSOUser : IDataSerializer
      {
          public byte? Isagent; 
          public long? UserID; 
          public Octets Account; 
          public Octets AgentName; 
          public Octets Agentaccount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTouchTrade : IDataSerializer
      {
          public long? Sn; 
          public byte? State; 
          public uint? Cost; 
          public uint? ItemId; 
          public uint? Count; 
          public uint? Lots; 
          public int? ExpireTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MInt : IDataSerializer
      {
          public int? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DiscountGrade : IDataSerializer
      {
          public int? AmountBegin; 
          public int? Discount; 
          public int? Reserved1; 
          public Octets Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MerchantDiscount : IDataSerializer
      {
          public int? Id; 
          public Octets Name; 
          public int? Reserved; 
          public Vector<DiscountGrade> Discount; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellID : IDataSerializer
      {
          public int? RoleId; 
          public int? SellIDValue; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DefSellPointRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellPointInfo : IDataSerializer
      {
          public int? SellID; 
          public int? RoleId; 
          public int? Point; 
          public int? Price; 
          public int? CTime; 
          public int? ETime; 
          public bool? Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellPointArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? Point; 
          public int? Price; 
          public int? Timestamp; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SellPointRes : IDataSerializer
      {
          public int? RetCode; 
          public int? SellID; 
          public int? CTime; 
          public int? ETime; 
          public bool? Status; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSyncSellInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<SellPointInfo> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBuyPointArg : IDataSerializer
      {
          public int? Buyer; 
          public uint? LocalSid; 
          public int? SellID; 
          public int? Seller; 
          public int? Timestamp; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBuyPointRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Point; 
          public int? Price; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TransID : IDataSerializer
      {
          public int? ZoneId; 
          public int? SerialNo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBTransPointDealRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<int> DelSell; 
          public int? GetMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutSpouseArg : IDataSerializer
      {
          public int? Oper; 
          public int? RId1; 
          public int? RId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RawKeyValue : IDataSerializer
      {
          public Octets Key; 
          public Octets Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRawReadArg : IDataSerializer
      {
          public Octets Table; 
          public Octets Handle; 
          public Octets Key; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRawReadRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets Handle; 
          public Vector<RawKeyValue> Values; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBClearConsumableArg : IDataSerializer
      {
          public int? UserID; 
          public int? LoginTime; 
          public byte? Dryrun; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockLog : IDataSerializer
      {
          public uint? TId; 
          public int? Time; 
          public short? Result; 
          public short? Volume; 
          public int? Cost; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GLoginRecord : IDataSerializer
      {
          public int? LoginTime; 
          public int? Loginip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GConsumptionRecord : IDataSerializer
      {
          public int? Consumption; 
          public int? Reserved; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserID : IDataSerializer
      {
          public uint? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class User : IDataSerializer
      {
          public uint? LogicUId; 
          public uint? RoleList; 
          public int? Cash; 
          public int? Money; 
          public uint? CashAdd; 
          public uint? CashBuy; 
          public uint? CashSell; 
          public uint? CashUsed; 
          public int? AddSerial; 
          public int? UseSerial; 
          public Vector<StockLog> ExgLog; 
          public Octets Addiction; 
          public Octets CashPassword; 
          public Vector<GPair> AutoLock; 
          public bool? Status; 
          public Vector<GRoleForbid> Forbid; 
          public Octets Reference; 
          public Octets ConsumeReward; 
          public Octets Taskcounter; 
          public Octets CashSysauction; 
          public Octets LoginRecord; 
          public Octets MallConsumption; 
          public short? Reserved32; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserArg : IDataSerializer
      {
          public uint? Id; 
          public int? LoginTime; 
          public int? Loginip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserRes : IDataSerializer
      {
          public int? RetCode; 
          public User Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserPair : IDataSerializer
      {
          public UserID Key; 
          public User Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleForbid : IDataSerializer
      {
          public byte? Type; 
          public int? Time; 
          public int? CreateTime; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleBase : IDataSerializer
      {
          public byte? Version; 
          public uint? Id; 
          public Octets Name; 
          public int? Race; 
          public int? Cls; 
          public byte? Gender; 
          public Octets CustomData; 
          public Octets ConfigData; 
          public uint? CustomStamp; 
          public bool? Status; 
          public int? DeleteTime; 
          public int? CreateTime; 
          public int? LastloginTime; 
          public Vector<GRoleForbid> Forbid; 
          public Octets HelpStates; 
          public uint? Spouse; 
          public uint? UserID; 
          public Octets CrossData; 
          public byte? Reserved2; 
          public byte? Reserved3; 
          public byte? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleStatus : IDataSerializer
      {
          public byte? Version; 
          public int? Level; 
          public int? Level2; 
          public int? Exp; 
          public int? Sp; 
          public int? Pp; 
          public int? Hp; 
          public int? Mp; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public int? Worldtag; 
          public int? InvaderState; 
          public int? InvaderTime; 
          public int? PariahTime; 
          public int? Reputation; 
          public Octets CustomStatus; 
          public Octets FilterData; 
          public Octets CharacterMode; 
          public Octets InstancekeyList; 
          public int? DoubleTimeExpire; 
          public int? DoubleTimeMode; 
          public int? DoubleTimeBegin; 
          public int? DoubleTimeUsed; 
          public int? DoubleTimeMax; 
          public int? TimeUsed; 
          public Octets DoubleTimeData; 
          public ushort? StoreSize; 
          public Octets Petcorral; 
          public Octets Property; 
          public Octets VarData; 
          public Octets Skills; 
          public Octets StorehousePasswd; 
          public Octets WaypointList; 
          public Octets CoolingTime; 
          public Octets NpcRelation; 
          public Octets MultiExpCtrl; 
          public Octets StorageTask; 
          public Octets FactionContrib; 
          public Octets ForceData; 
          public Octets OnlineAward; 
          public Octets ProfitTimeData; 
          public Octets CountryData; 
          public Octets KingData; 
          public Octets MeridianData; 
          public Octets ExtraProp; 
          public Octets TitleData; 
          public Octets ReincarnationData; 
          public Octets RealmData; 
          public byte? Reserved2; 
          public byte? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleInventory : IDataSerializer
      {
          public uint? Id; 
          public int? Pos; 
          public int? Count; 
          public int? MaxCount; 
          public Octets Data; 
          public int? ProcType; 
          public int? ExpireDate; 
          public int? GUId1; 
          public int? GUId2; 
          public int? Mask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleStorehouse : IDataSerializer
      {
          public uint? Capacity; 
          public uint? Money; 
          public Vector<GRoleInventory> Items; 
          public byte? Size1; 
          public byte? Size2; 
          public Vector<GRoleInventory> Dress; 
          public Vector<GRoleInventory> Material; 
          public byte? Size3; 
          public Vector<GRoleInventory> Generalcard; 
          public short? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GUserStoreHouse : IDataSerializer
      {
          public int? Capacity; 
          public uint? Money; 
          public Vector<GRoleInventory> Items; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GSysLog : IDataSerializer
      {
          public int? RoleId; 
          public int? Time; 
          public int? Ip; 
          public short? Source; 
          public int? Money; 
          public Vector<GRoleInventory> Items; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRolePocket : IDataSerializer
      {
          public uint? Capacity; 
          public uint? Timestamp; 
          public uint? Money; 
          public Vector<GRoleInventory> Items; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTask : IDataSerializer
      {
          public Octets TaskData; 
          public Octets TaskComplete; 
          public Octets TaskFinishTime; 
          public Vector<GRoleInventory> TaskInventory; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleEquipment : IDataSerializer
      {
          public Vector<GRoleInventory> Inv; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleData : IDataSerializer
      {
          public GRoleBase Base; 
          public GRoleStatus Status; 
          public GRolePocket Pocket; 
          public GRoleEquipment Equipment; 
          public GRoleStorehouse Storehouse; 
          public GRoleTask Task; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GPet : IDataSerializer
      {
          public int? Index; 
          public Octets Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GPetCorral : IDataSerializer
      {
          public int? Capacity; 
          public Vector<GPet> Pets; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GShopLog : IDataSerializer
      {
          public int? RoleId; 
          public int? OrderId; 
          public int? ItemId; 
          public int? Expire; 
          public int? ItemCount; 
          public int? OrderCount; 
          public int? CashNeed; 
          public int? Time; 
          public int? GUId1; 
          public int? GUId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GUniqueDataElem : IDataSerializer
      {
          public byte? VType; 
          public Octets Value; 
          public int? Version; 
          public short? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GUniqueDataElemNode : IDataSerializer
      {
          public int? Key; 
          public GUniqueDataElem Val; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GForceData : IDataSerializer
      {
          public int? ForceId; 
          public int? Reputation; 
          public int? Contribution; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 
          public int? Reserved7; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GForceDataList : IDataSerializer
      {
          public int? CurForceId; 
          public Vector<GForceData> List; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMeridianData : IDataSerializer
      {
          public int? MeridianLevel; 
          public int? LifegateTimes; 
          public int? DeathgateTimes; 
          public int? FreeRefineTimes; 
          public int? PaidRefineTimes; 
          public int? PlayerLoginTime; 
          public int? ContinuLoginDays; 
          public int? TrigramsMap1; 
          public int? TrigramsMap2; 
          public int? TrigramsMap3; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GReincarnationRecord : IDataSerializer
      {
          public int? Level; 
          public int? Timestamp; 
          public int? Exp; 
          public int? Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GReincarnationData : IDataSerializer
      {
          public int? TomeExp; 
          public byte? TomeActive; 
          public Vector<GReincarnationRecord> Records; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleInfo : IDataSerializer
      {
          public byte? Version; 
          public uint? Id; 
          public Octets Name; 
          public int? Race; 
          public int? Cls; 
          public byte? Gender; 
          public int? Level; 
          public int? Level2; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 
          public int? Worldtag; 
          public Octets CustomData; 
          public uint? CustomStamp; 
          public Octets CustomStatus; 
          public Octets CharacterMode; 
          public Vector<GRoleInventory> Equipment; 
          public bool? Status; 
          public int? DeleteTime; 
          public int? CreateTime; 
          public int? LastloginTime; 
          public Vector<GRoleForbid> Forbid; 
          public int? ReferrerRole; 
          public int? CashAdd; 
          public CrossInfoData CrossData; 
          public Octets ReincarnationData; 
          public Octets RealmData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleDetail : IDataSerializer
      {
          public byte? Version; 
          public uint? Id; 
          public uint? UserID; 
          public GRoleStatus Status; 
          public Octets Name; 
          public int? Race; 
          public int? Cls; 
          public uint? Spouse; 
          public byte? Gender; 
          public int? CreateTime; 
          public int? LastloginTime; 
          public int? CashAdd; 
          public int? CashTotal; 
          public int? CashUsed; 
          public int? CashSerial; 
          public uint? FactionId; 
          public int? Factionrole; 
          public Octets CustomData; 
          public uint? CustomStamp; 
          public GRolePocket Inventory; 
          public Vector<GRoleInventory> Equipment; 
          public GRoleStorehouse Storehouse; 
          public GRoleTask Task; 
          public Octets Addiction; 
          public Vector<GShopLog> Logs; 
          public int? BonusAdd; 
          public int? BonusReward; 
          public int? BonusUsed; 
          public int? Referrer; 
          public GUserStoreHouse UserStoreHouse; 
          public Octets Taskcounter; 
          public Vector<GFactionAlliance> FactionAlliance; 
          public Vector<GFactionHostile> FactionHostile; 
          public int? MallConsumption; 
          public int? SrcZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableUser : IDataSerializer
      {
          public User User; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableBase : IDataSerializer
      {
          public GRoleBase Base; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableStatus : IDataSerializer
      {
          public GRoleStatus Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableInventory : IDataSerializer
      {
          public GRolePocket Inventory; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableEquipment : IDataSerializer
      {
          public Vector<GRoleInventory> Inv; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableStorehouse : IDataSerializer
      {
          public GRoleStorehouse Storehouse; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableTask : IDataSerializer
      {
          public GRoleTask TaskData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableFriendlist : IDataSerializer
      {
          public GFriendList FriendList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableMessages : IDataSerializer
      {
          public Vector<Message> Messages; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableClsConfig : IDataSerializer
      {
          public byte? Version; 
          public GRoleBase Base; 
          public GRoleStatus Status; 
          public GRolePocket Inventory; 
          public Vector<GRoleInventory> Equipment; 
          public GRoleStorehouse Storehouse; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableRolename : IDataSerializer
      {
          public RoleId Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleTableWaitdel : IDataSerializer
      {
          public int? DeleteTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTableDefinition : IDataSerializer
      {
          public User User; 
          public GRoleBase Base; 
          public GRoleStatus Status; 
          public GRoleTask Task; 
          public GRolePocket Inventory; 
          public GRoleEquipment Equipment; 
          public GRoleStorehouse Storehouse; 
          public GMailBox Mailbox; 
          public GFriendList Friends; 
          public Vector<Message> Messages; 
          public GFactionInfo FactionInfo; 
          public StockOrder Order; 
          public GSysLog Syslog; 
          public Octets Config; 
          public int? FactionName; 
          public int? WaitDel; 
          public GRoleTableClsConfig ClsConfig; 
          public int? RoleName; 
          public byte? ShopLog; 
          public GAuctionDetail Auction; 
          public GUserFaction UserFaction; 
          public byte? SellPoint; 
          public byte? TransLog; 
          public GTerritoryStore City; 
          public Octets GTask; 
          public GUserStoreHouse UserStore; 
          public GWebTradeDetail WebTrade; 
          public GWebTradeDetail WebTradesOld; 
          public GServerData ServerData; 
          public GFactionFortressDetail FactionFortress; 
          public GFactionRelation Factionrelation; 
          public GForceGlobalDataList Force; 
          public GFriendExtra Friendext; 
          public GGlobalControlData Globalcontrol; 
          public Octets RoleNameHis; 
          public KingElectionDetail KingElection; 
          public PShopDetail PlayerShop; 
          public WebOrderItemDetail WeborderItem; 
          public PlayerProfileData PlayerProfile; 
          public GUniqueDataElem UniqueData; 
          public byte? RecallUser; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleId : IDataSerializer
      {
          public uint? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleArg : IDataSerializer
      {
          public RoleId Key; 
          public int? DataMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleRes : IDataSerializer
      {
          public int? RetCode; 
          public int? DataMask; 
          public byte? GameServerId; 
          public GRoleDetail Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCreateRoleArg : IDataSerializer
      {
          public int? UserID; 
          public uint? LogicUId; 
          public int? RoleId; 
          public RoleInfo RoleInfo; 
          public int? AuSuggestReferrer; 
          public int? PlayerSuggestReferrer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCreateRoleRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? RoleList; 
          public RoleInfo RoleInfo; 
          public int? RealReferrer; 
          public int? RefretCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBDeleteRoleArg : IDataSerializer
      {
          public int? RoleId; 
          public byte? CreateRollback; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBDeleteRoleRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 
          public uint? RoleList; 
          public uint? Faction; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUndoDeleteRoleArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUndoDeleteRoleRes : IDataSerializer
      {
          public int? RetCode; 
          public byte? GameServerId; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountAddRoleArg : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public byte? ZoneId; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountAddRoleRes : IDataSerializer
      {
          public byte? RetCode; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountDelRoleArg : IDataSerializer
      {
          public byte? ZoneId; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AccountDelRoleRes : IDataSerializer
      {
          public byte? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleBasePair : IDataSerializer
      {
          public RoleId Key; 
          public GRoleBase Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleBaseRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleBase Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusPair : IDataSerializer
      {
          public RoleId Key; 
          public GRoleStatus Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleStatus Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleEquipmentPair : IDataSerializer
      {
          public RoleId Key; 
          public Vector<GRoleInventory> Equipment; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleEquipmentRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GRoleInventory> Equipment; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleTaskPair : IDataSerializer
      {
          public RoleId Key; 
          public GRoleTask Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleTaskRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleTask Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleDataPair : IDataSerializer
      {
          public RoleId Key; 
          public byte? OverWrite; 
          public GRoleData Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleDataRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleData Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBModifyRoleDataArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? Mask; 
          public int? Level; 
          public long? Exp; 
          public uint? PocketMoney; 
          public uint? StoreMoney; 
          public int? PKValue; 
          public int? Reputation; 
          public int? Potential; 
          public int? Occupation; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBModifyRoleDataRes : IDataSerializer
      {
          public int? RetCode; 
          public long? TotalMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeInventoryArg : IDataSerializer
      {
          public uint? RoleId1; 
          public uint? RoleId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeInventoryRes : IDataSerializer
      {
          public int? RetCode; 
          public GRolePocket Pocket1; 
          public GRolePocket Pocket2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeSaveArg : IDataSerializer
      {
          public uint? RoleId1; 
          public uint? RoleId2; 
          public uint? Money1; 
          public uint? Money2; 
          public Vector<GRoleInventory> Goods1; 
          public Vector<GRoleInventory> Goods2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeSaveRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMoneyInventoryArg : IDataSerializer
      {
          public int? RoleId; 
          public int? DataMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMoneyInventoryRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Timestamp; 
          public uint? Money; 
          public Vector<GRoleInventory> Goods; 
          public int? DataMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutMoneyInventoryArg : IDataSerializer
      {
          public uint? RoleId; 
          public uint? Money; 
          public Vector<GRoleInventory> Goods; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RolePair : IDataSerializer
      {
          public RoleId Key; 
          public int? DataMask; 
          public byte? Priority; 
          public GRoleDetail Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRoleBaseStatusRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleBase Base; 
          public GRoleStatus Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStorehousePair : IDataSerializer
      {
          public RoleId Key; 
          public GRoleStorehouse Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStorehouseRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleStorehouse Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleForbidPair : IDataSerializer
      {
          public RoleId Key; 
          public Vector<GRoleForbid> Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRoleForbidArg : IDataSerializer
      {
          public RoleId Key; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRoleForbidRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GRoleForbid> Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRoleIdArg : IDataSerializer
      {
          public Octets RoleName; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetRoleIdRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TransactionTimeout : IDataSerializer
      {
          public uint? Timeout; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TransactionId : IDataSerializer
      {
          public uint? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateRoleArg : IDataSerializer
      {
          public int? ZoneId; 
          public int? UserID; 
          public int? UseLogic; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateRoleRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 
          public uint? LogicUId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateRoleArg : IDataSerializer
      {
          public byte? Success; 
          public int? UserID; 
          public int? ZoneId; 
          public int? RoleId; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateRoleRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteRoleArg : IDataSerializer
      {
          public int? UserID; 
          public int? ZoneId; 
          public int? RoleId; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteRoleRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateFactionArg : IDataSerializer
      {
          public int? ZoneId; 
          public Octets FactionName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateFactionRes : IDataSerializer
      {
          public int? RetCode; 
          public int? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateFactionArg : IDataSerializer
      {
          public byte? Success; 
          public int? ZoneId; 
          public int? FactionId; 
          public Octets FactionName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateFactionRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteFactionArg : IDataSerializer
      {
          public int? ZoneId; 
          public int? FactionId; 
          public Octets FactionName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteFactionRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateFamilyArg : IDataSerializer
      {
          public int? ZoneId; 
          public Octets FamilyName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PreCreateFamilyRes : IDataSerializer
      {
          public int? RetCode; 
          public int? FamilyId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateFamilyArg : IDataSerializer
      {
          public byte? Success; 
          public int? ZoneId; 
          public int? FamilyId; 
          public Octets FamilyName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostCreateFamilyRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteFamilyArg : IDataSerializer
      {
          public int? ZoneId; 
          public int? FamilyId; 
          public Octets FamilyName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostDeleteFamilyRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleInfo Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RolePocketPair : IDataSerializer
      {
          public RoleId Key; 
          public GRolePocket Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RolePocketRes : IDataSerializer
      {
          public int? RetCode; 
          public GRolePocket Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PrePlayerRenameArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ZoneId; 
          public int? UserID; 
          public Octets NewName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PrePlayerRenameRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerRenameArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemNumber; 
          public int? ItemPos; 
          public Octets NewName; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerRenameRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets OldName; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleNameHis : IDataSerializer
      {
          public Octets OldName; 
          public int? RenameTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoleIDandName : IDataSerializer
      {
          public int? RoleId; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRoleNameListArg : IDataSerializer
      {
          public int? Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRoleNameListRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Handle; 
          public byte? Finish; 
          public Vector<GRoleIDandName> RoleNameList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerGivePresentArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? TargetRoleId; 
          public int? MailId; 
          public Vector<GRoleInventory> Goods; 
          public uint? CashCost; 
          public byte? HasGift; 
          public int? LogPrice1; 
          public int? LogPrice2; 
          public Octets RoleName; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerGivePresentRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailHeader InformTarget; 
          public GMailHeader InformTarget2; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerAskForPresentArg : IDataSerializer
      {
          public int? RoleId; 
          public int? TargetRoleId; 
          public int? GoodsId; 
          public int? GoodsIndex; 
          public int? GoodsSlot; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerAskForPresentRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailHeader InformTarget; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GServerData : IDataSerializer
      {
          public int? Worldtag; 
          public Octets WeddingData; 
          public Octets DpsrankData; 
          public byte? Reserved11; 
          public short? Reserved12; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutServerDataArg : IDataSerializer
      {
          public int? Worldtag; 
          public int? DataMask; 
          public int? Priority; 
          public GServerData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetServerDataArg : IDataSerializer
      {
          public int? Worldtag; 
          public int? DataMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetServerDataRes : IDataSerializer
      {
          public int? RetCode; 
          public int? DataMask; 
          public GServerData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetCashTotalArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetCashTotalRes : IDataSerializer
      {
          public int? RetCode; 
          public int? CashTotal; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSetCashPasswordArg : IDataSerializer
      {
          public int? UserID; 
          public int? Source; 
          public Octets Password; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSetCashPasswordRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerPositionResetArg : IDataSerializer
      {
          public int? RoleId; 
          public int? Worldtag; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPlayerPositionResetRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GGlobalControlData : IDataSerializer
      {
          public byte? CashMoneyExchangeOpen; 
          public int? CashMoneyExchangeRate; 
          public Vector<int> ForbidCtrlList; 
          public Vector<int> ForbidItemList; 
          public Vector<int> ForbidServiceList; 
          public Vector<int> ForbidTaskList; 
          public Vector<int> ForbidSkillList; 
          public Vector<int> TriggerCtrlList; 
          public byte? Reserved12; 
          public byte? Reserved13; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 
          public int? Reserved7; 
          public int? Reserved8; 
          public int? Reserved9; 
          public int? Reserved10; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBLoadGlobalControlArg : IDataSerializer
      {
          public int? Nouse; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBLoadGlobalControlRes : IDataSerializer
      {
          public int? RetCode; 
          public GGlobalControlData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutGlobalControlArg : IDataSerializer
      {
          public GGlobalControlData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutGlobalControlRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUniqueDataLoadArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUniqueDataLoadRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GUniqueDataElemNode> Values; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUniqueDataSaveArg : IDataSerializer
      {
          public Vector<GUniqueDataElemNode> Values; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUniqueDataSaveRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetUserRolesArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ClearStorehousePasswdArg : IDataSerializer
      {
          public int? RoleId; 
          public Octets RoleName; 
          public Octets Reserved; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CanChangeRolenameArg : IDataSerializer
      {
          public Octets RoleName; 
          public int? SetCanChange; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CanChangeRolenameRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RenameRoleArg : IDataSerializer
      {
          public int? RoleId; 
          public Octets OldName; 
          public Octets NewName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Uid2LogicuidArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Uid2LogicuidRes : IDataSerializer
      {
          public int? RetCode; 
          public int? LogicUId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Roleid2UidArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Roleid2UidRes : IDataSerializer
      {
          public int? RetCode; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RolenameExistsArg : IDataSerializer
      {
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RolenameExistsRes : IDataSerializer
      {
          public int? RetCode; 
          public int? ZoneId; 
          public int? RoleId; 
          public int? Status; 
          public int? Time; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserRoleCountArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserRoleCountRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Count; 
          public uint? RoleList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MoveRoleCreateArg : IDataSerializer
      {
          public int? FromZoneId; 
          public int? ZoneId; 
          public int? UserID; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MoveRoleCreateRes : IDataSerializer
      {
          public int? RetCode; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeStartRqstArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? LocalSid; 
          public int? StartRoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TradeStartRqstRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBConfig : IDataSerializer
      {
          public uint? InitTime; 
          public uint? OpenTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBConfig2 : IDataSerializer
      {
          public uint? IsCentralDb; 
          public uint? Reserve; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailID : IDataSerializer
      {
          public int? RoleId; 
          public byte? MailId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailDefRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailHeader : IDataSerializer
      {
          public byte? Id; 
          public int? Sender; 
          public byte? SndrType; 
          public int? Receiver; 
          public Octets Title; 
          public int? SendTime; 
          public byte? Attribute; 
          public Octets SenderName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMail : IDataSerializer
      {
          public GMailHeader Header; 
          public Octets Context; 
          public GRoleInventory AttachObj; 
          public uint? AttachMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailSyncData : IDataSerializer
      {
          public int? DataMask; 
          public int? CashTotal; 
          public uint? CashUsed; 
          public int? CashSerial; 
          public GRolePocket Inventory; 
          public GRoleStorehouse Storehouse; 
          public Vector<GRoleInventory> Equipment; 
          public Vector<GShopLog> Logs; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMailBox : IDataSerializer
      {
          public uint? Timestamp; 
          public uint? Status; 
          public Vector<GMail> Mails; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MailGoodsInventory : IDataSerializer
      {
          public int? GoodsId; 
          public int? Count; 
          public int? ProcType; 
          public int? GoodsFlag; 
          public int? GoodsPrice; 
          public int? GoodsPriceBeforeDiscount; 
          public int? PayType; 
          public Octets Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebOrderItemDetail : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public int? GoodsId; 
          public int? Count; 
          public int? ProcType; 
          public int? GoodsFlag; 
          public int? GoodsPrice; 
          public int? GoodsPriceBeforeDiscount; 
          public int? GoodsPayType; 
          public uint? AttachMoney; 
          public int? Timestamp; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysMail3Arg : IDataSerializer
      {
          public long? OrderId; 
          public int? UserID; 
          public long? RoleId; 
          public Octets RoleName; 
          public int? GoodsFlag; 
          public int? GoodsPrice; 
          public int? GoodsPriceBeforeDiscount; 
          public int? GoodsPayType; 
          public GMail Mail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysMail3Res : IDataSerializer
      {
          public int? RetCode; 
          public byte? MailId; 
          public long? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetMailListRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GMailHeader> MailList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetMailRes : IDataSerializer
      {
          public byte? RetCode; 
          public GMail Mail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetMailAttachArg : IDataSerializer
      {
          public GMailID MailId; 
          public byte? AttachType; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetMailAttachRes : IDataSerializer
      {
          public byte? RetCode; 
          public uint? MoneyLeft; 
          public uint? ItemLeft; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSetMailAttrArg : IDataSerializer
      {
          public GMailID MailId; 
          public byte? AttribType; 
          public byte? AttribValue; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSetMailAttrRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSendMailArg : IDataSerializer
      {
          public GMail Mail; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSendMailRes : IDataSerializer
      {
          public byte? RetCode; 
          public byte? MailId; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBDeleteMailArg : IDataSerializer
      {
          public int? RoleId; 
          public Octets MailId; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSendMassMailArg : IDataSerializer
      {
          public byte? MassType; 
          public GMail Mail; 
          public int? CostObjId; 
          public int? CostObjNum; 
          public int? CostObjPos; 
          public uint? CostMoney; 
          public Vector<int> ReceiverList; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class MassMailRes : IDataSerializer
      {
          public int? RoleId; 
          public byte? MailId; 
          public byte? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSendMassMailRes : IDataSerializer
      {
          public byte? RetCode; 
          public Vector<MassMailRes> Result; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GWebTradeItem : IDataSerializer
      {
          public long? Sn; 
          public int? SellerroleId; 
          public int? SellerUserId; 
          public Octets SellerName; 
          public int? PostType; 
          public uint? Money; 
          public uint? ItemId; 
          public int? ItemCount; 
          public int? State; 
          public int? PostEndTime; 
          public int? ShowEndTime; 
          public int? Price; 
          public int? SellEndTime; 
          public int? BuyerroleId; 
          public int? BuyerUserId; 
          public Octets BuyerName; 
          public int? CommodityId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GWebTradeRoleBriefExtend : IDataSerializer
      {
          public Octets MeridianData; 
          public Octets CardLeadership; 
          public Octets FateRingData; 
          public Octets TitleData; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GWebTradeRoleBrief : IDataSerializer
      {
          public int? Cls; 
          public byte? Gender; 
          public int? Level; 
          public int? Level2; 
          public int? Exp; 
          public int? Sp; 
          public int? Pp; 
          public int? Reputation; 
          public Octets Petcorral; 
          public Octets Property; 
          public Octets Skills; 
          public GRolePocket Inventory; 
          public GRoleEquipment Equipment; 
          public GRoleStorehouse Storehouse; 
          public Octets ForceData; 
          public Octets ReincarnationData; 
          public Octets RealmData; 
          public Octets ExtendData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GWebTradeDetail : IDataSerializer
      {
          public GWebTradeItem Info; 
          public GRoleInventory Item; 
          public long? PostTime; 
          public uint? Deposit; 
          public int? Loginip; 
          public Octets Rolebrief; 
          public byte? Reserved10; 
          public short? Reserved11; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeLoadArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeLoadRes : IDataSerializer
      {
          public int? RetCode; 
          public long? MaxSn; 
          public Vector<GWebTradeDetail> Items; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePrePostArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? UserID; 
          public Octets Name; 
          public int? PostType; 
          public uint? Money; 
          public uint? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? Price; 
          public int? SellPeriod; 
          public int? BuyerroleId; 
          public long? PostTime; 
          public int? State; 
          public uint? Deposit; 
          public int? Loginip; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePrePostRes : IDataSerializer
      {
          public int? RetCode; 
          public int? BuyerUserId; 
          public Octets BuyerName; 
          public Octets Name; 
          public Octets Rolebrief; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePreCancelPostArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? State; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePreCancelPostRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePostArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? State; 
          public int? PostEndTime; 
          public int? ShowEndTime; 
          public int? SellEndTime; 
          public int? CommodityId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePostRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeCancelPostArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeCancelPostRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailHeader InformSeller; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeShelfArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? State; 
          public int? ShowEndTime; 
          public int? Price; 
          public int? SellEndTime; 
          public int? BuyerroleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeShelfRes : IDataSerializer
      {
          public int? RetCode; 
          public int? BuyerUserId; 
          public Octets BuyerName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeCancelShelfArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? State; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeCancelShelfRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeSoldArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 
          public int? BuyerroleId; 
          public int? BuyerUserId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeSoldRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailHeader InformSeller; 
          public GMailHeader InformBuyer; 
          public int? BuyerroleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePostExpireArg : IDataSerializer
      {
          public long? Sn; 
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradePostExpireRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailHeader InformSeller; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleSimpleInfo : IDataSerializer
      {
          public long? RoleId; 
          public int? Level; 
          public int? Race; 
          public int? Gender; 
          public Octets Name; 
          public int? ReincarnationTimes; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeGetRoleSimpleInfoArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeGetRoleSimpleInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<RoleSimpleInfo> Roles; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeLoadSoldArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBWebTradeLoadSoldRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<long> SnList; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TraderInfo : IDataSerializer
      {
          public int? UserID; 
          public long? RoleId; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PostInfo : IDataSerializer
      {
          public Octets Detail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TimeInfo : IDataSerializer
      {
          public long? ActionTime; 
          public int? ShowPeriod; 
          public int? SellPeriod; 
          public int? PostPeriod; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class WebRole : IDataSerializer
      {
          public Octets Info; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GSysAuctionItem : IDataSerializer
      {
          public uint? SaId; 
          public uint? ItemId; 
          public int? ItemCount; 
          public uint? BasePrice; 
          public int? State; 
          public int? AuctionStartTime; 
          public int? AuctionEndTime; 
          public uint? BidPrice; 
          public int? BidTime; 
          public int? BidFreezeTime; 
          public int? BidderRoleId; 
          public int? BidderUseRId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GSysAuctionDetail : IDataSerializer
      {
          public GSysAuctionItem Info; 
          public GRoleInventory Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GSysAuctionCash : IDataSerializer
      {
          public uint? Cash2; 
          public uint? CashUsed2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysAuctionCashTransferArg : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public byte? WithDraw; 
          public uint? CashTransfer; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysAuctionCashTransferRes : IDataSerializer
      {
          public int? RetCode; 
          public uint? Cash; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysAuctionCashSpendArg : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public uint? CashSpend; 
          public uint? SaId; 
          public GRoleInventory Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBSysAuctionCashSpendRes : IDataSerializer
      {
          public int? RetCode; 
          public uint? Cash; 
          public uint? CashUsed; 
          public GMailHeader InformBidder; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionPrepareItemArg : IDataSerializer
      {
          public Vector<int> Indexes; 
          public Vector<int> ItemIds; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SysAuctionPrepareItemRes : IDataSerializer
      {
          public Vector<int> Indexes; 
          public Vector<GRoleInventory> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionFortressInfo : IDataSerializer
      {
          public int? Level; 
          public int? Exp; 
          public int? ExpToday; 
          public int? ExpTodayTime; 
          public int? TechPoint; 
          public Octets Technology; 
          public Octets Material; 
          public Octets Building; 
          public Octets CommonValue; 
          public Octets ActivedSpawner; 
          public byte? Reserved11; 
          public short? Reserved12; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionFortressInfo2 : IDataSerializer
      {
          public int? Health; 
          public int? OffenseFaction; 
          public int? OffenseStartTime; 
          public int? OffenseEndTime; 
          public Vector<int> ChallengeList; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionFortressDetail : IDataSerializer
      {
          public int? FactionId; 
          public GFactionFortressInfo Info; 
          public GFactionFortressInfo2 Info2; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionFortressBriefInfo : IDataSerializer
      {
          public int? FactionId; 
          public int? Level; 
          public Octets Building; 
          public int? Health; 
          public int? OffenseFaction; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionFortressBattleInfo : IDataSerializer
      {
          public int? FactionId; 
          public int? OffenseFaction; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionFortressLoadArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionFortressLoadRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GFactionFortressDetail> List; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutFactionFortressArg : IDataSerializer
      {
          public GFactionFortressDetail Detail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutFactionFortressRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBDelFactionFortressArg : IDataSerializer
      {
          public int? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBDelFactionFortressRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFactionFortressArg : IDataSerializer
      {
          public int? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetFactionFortressRes : IDataSerializer
      {
          public int? RetCode; 
          public GFactionFortressDetail Detail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutFactionFortressArg : IDataSerializer
      {
          public int? FactionId; 
          public GFactionFortressInfo Info; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PutFactionFortressRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCreateFactionFortressArg : IDataSerializer
      {
          public int? RoleId; 
          public Octets ItemCost; 
          public GFactionFortressDetail Detail; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCreateFactionFortressRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionFortressChallengeArg : IDataSerializer
      {
          public int? RoleId; 
          public int? FactionId; 
          public int? TargetFactionId; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionFortressChallengeRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AuctionId : IDataSerializer
      {
          public uint? Id; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GAuctionItem : IDataSerializer
      {
          public uint? AuctionId; 
          public uint? BidPrice; 
          public uint? BinPrice; 
          public uint? EndTime; 
          public uint? ItemId; 
          public ushort? Count; 
          public uint? Seller; 
          public uint? Bidder; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GAuctionDetail : IDataSerializer
      {
          public GAuctionItem Info; 
          public ushort? Category; 
          public uint? BasePrice; 
          public uint? Deposit; 
          public int? ElapseTime; 
          public int? Prolong; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public GRoleInventory Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionOpenArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public ushort? Category; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public uint? BasePrice; 
          public uint? BinPrice; 
          public int? ElapseTime; 
          public int? EndTime; 
          public uint? Deposit; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionOpenRes : IDataSerializer
      {
          public byte? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionBidArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? AuctionId; 
          public uint? BidPrice; 
          public byte? Bin; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionBidRes : IDataSerializer
      {
          public byte? RetCode; 
          public uint? BidPrice; 
          public GMailHeader InformSeller; 
          public GMailHeader InformLoser; 
          public GMailHeader InformWinner; 
          public int? ExtendTime; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GAuctionList : IDataSerializer
      {
          public ushort? Category; 
          public Vector<GAuctionDetail> List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GAuctionIndex : IDataSerializer
      {
          public Octets Category; 
          public int? Index; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionListArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionListRes : IDataSerializer
      {
          public short? RetCode; 
          public Vector<GAuctionDetail> Items; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionGetArg : IDataSerializer
      {
          public uint? AuctionId; 
          public byte? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionGetRes : IDataSerializer
      {
          public byte? RetCode; 
          public GAuctionDetail Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionTimeoutRes : IDataSerializer
      {
          public byte? RetCode; 
          public uint? AuctionId; 
          public GMailHeader InformSeller; 
          public GMailHeader InformBidder; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionCloseArg : IDataSerializer
      {
          public int? RoleId; 
          public byte? Reason; 
          public uint? AuctionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAuctionCloseRes : IDataSerializer
      {
          public byte? RetCode; 
          public GMailHeader InformSeller; 
          public GMailHeader InformBidder; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GChallengerInfoList : IDataSerializer
      {
          public Vector<GChallengerInfo> ChallengerList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GChallengerInfo : IDataSerializer
      {
          public uint? Faction; 
          public int? Time; 
          public uint? Deposit; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTerritoryDetail : IDataSerializer
      {
          public short? Id; 
          public short? Level; 
          public uint? Owner; 
          public int? OccupyTime; 
          public uint? Challenger; 
          public uint? Deposit; 
          public int? CutffTime; 
          public int? BattleTime; 
          public int? BonusTime; 
          public int? Color; 
          public int? Status; 
          public int? Timeout; 
          public int? Maxbonus; 
          public int? ChallengeTime; 
          public Octets Challengerdetails; 
          public byte? Reserved1; 
          public byte? Reserved2; 
          public byte? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTerritoryStore : IDataSerializer
      {
          public Vector<GTerritoryDetail> Cities; 
          public int? Status; 
          public int? SpecialTime; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GTerritory : IDataSerializer
      {
          public byte? Id; 
          public byte? Level; 
          public byte? Color; 
          public uint? Owner; 
          public uint? Challenger; 
          public uint? BattleTime; 
          public int? Deposit; 
          public int? Maxbonus; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GCity : IDataSerializer
      {
          public byte? Id; 
          public byte? Level; 
          public uint? Owner; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GBattleChallenge : IDataSerializer
      {
          public short? Id; 
          public uint? Challenger; 
          public uint? Deposit; 
          public uint? Maxbonus; 
          public uint? CutffTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleEndArg : IDataSerializer
      {
          public int? BattleId; 
          public int? Result; 
          public uint? Defender; 
          public uint? Attacker; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class BattleEndRes : IDataSerializer
      {
          public short? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleLoadArg : IDataSerializer
      {
          public int? Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleLoadRes : IDataSerializer
      {
          public short? RetCode; 
          public Vector<GTerritoryDetail> Cities; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleSetArg : IDataSerializer
      {
          public short? Reason; 
          public Vector<GTerritoryDetail> Cities; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleSetRes : IDataSerializer
      {
          public short? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleChallengeArg : IDataSerializer
      {
          public int? RoleId; 
          public short? CityId; 
          public int? FactionId; 
          public uint? Deposit; 
          public uint? Maxbonus; 
          public int? ChallengeTime; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleChallengeRes : IDataSerializer
      {
          public short? RetCode; 
          public int? ChallengeRes; 
          public uint? Deposit; 
          public GMailHeader InformLoser; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleEndArg : IDataSerializer
      {
          public int? BattleId; 
          public int? Result; 
          public int? Color; 
          public uint? Defender; 
          public uint? Attacker; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleEndRes : IDataSerializer
      {
          public short? RetCode; 
          public GMailHeader InformWinner; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleMailArg : IDataSerializer
      {
          public uint? FactionId; 
          public GMail Mail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleMailRes : IDataSerializer
      {
          public byte? RetCode; 
          public uint? RoleId; 
          public byte? MailId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleBonusArg : IDataSerializer
      {
          public uint? FactionId; 
          public short? CityId; 
          public uint? Money; 
          public GRoleInventory Item; 
          public short? Isspecialbonus; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBBattleBonusRes : IDataSerializer
      {
          public short? RetCode; 
          public GMailHeader InformMaster; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopItem : IDataSerializer
      {
          public GRoleInventory Item; 
          public uint? Price; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopBase : IDataSerializer
      {
          public int? RoleId; 
          public int? ShopType; 
          public Vector<PShopItem> BList; 
          public Vector<PShopItem> SList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopDetail : IDataSerializer
      {
          public int? RoleId; 
          public int? ShopType; 
          public int? Status; 
          public int? CreateTime; 
          public int? ExpireTime; 
          public uint? Money; 
          public Vector<GRoleInventory> Yinpiao; 
          public Vector<PShopItem> BList; 
          public Vector<PShopItem> SList; 
          public Vector<GRoleInventory> Store; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopEntry : IDataSerializer
      {
          public int? RoleId; 
          public int? ShopType; 
          public int? CreateTime; 
          public int? Invstate; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PShopItemEntry : IDataSerializer
      {
          public int? RoleId; 
          public PShopItem Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopCreateArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ShopType; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? CreateTime; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopCreateRes : IDataSerializer
      {
          public int? RetCode; 
          public PShopDetail Shop; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopBuyArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopBuyRes : IDataSerializer
      {
          public int? RetCode; 
          public PShopItem ItemBuy; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopSellArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public uint? ItemPrice; 
          public int? InvPos; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopSellRes : IDataSerializer
      {
          public int? RetCode; 
          public PShopItem ItemSell; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopCancelGoodsArg : IDataSerializer
      {
          public int? RoleId; 
          public int? CancelType; 
          public int? ItemPos; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopCancelGoodsRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleInventory ItemStore; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopPlayerBuyArg : IDataSerializer
      {
          public int? RoleId; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public long? MoneyCost; 
          public int? YpCost; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopPlayerBuyRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 
          public uint? Money; 
          public Vector<GRoleInventory> Yinpiao; 
          public PShopItem ItemChange; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopPlayerSellArg : IDataSerializer
      {
          public int? RoleId; 
          public int? Master; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemCount; 
          public int? InvPos; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopPlayerSellRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 
          public uint? Money; 
          public Vector<GRoleInventory> Yinpiao; 
          public PShopItem ItemBuyChange; 
          public GRoleInventory ItemStoreChange; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopSetTypeArg : IDataSerializer
      {
          public int? RoleId; 
          public int? NewType; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopSetTypeRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopActiveArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? Timestamp; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopActiveRes : IDataSerializer
      {
          public int? RetCode; 
          public PShopDetail Detail; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopManageFundArg : IDataSerializer
      {
          public int? RoleId; 
          public int? OpType; 
          public uint? Money; 
          public uint? Yinpiao; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopManageFundRes : IDataSerializer
      {
          public int? RetCode; 
          public uint? Money; 
          public Vector<GRoleInventory> Yinpiao; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopDrawItemArg : IDataSerializer
      {
          public int? RoleId; 
          public int? ItemPos; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopDrawItemRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopLoadArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopLoadRes : IDataSerializer
      {
          public short? RetCode; 
          public Vector<PShopDetail> Shops; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopGetArg : IDataSerializer
      {
          public int? RoleId; 
          public int? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopGetRes : IDataSerializer
      {
          public int? RetCode; 
          public PShopDetail Shop; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopClearGoodsArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopClearGoodsRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<PShopItem> SList; 
          public Vector<GRoleInventory> Store; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopTimeoutArg : IDataSerializer
      {
          public int? RoleId; 
          public bool? DelFlag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPShopTimeoutRes : IDataSerializer
      {
          public int? RetCode; 
          public Vector<GMailHeader> MailList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerProfileData : IDataSerializer
      {
          public ushort? GameTimeMask; 
          public ushort? GameInterestMask; 
          public ushort? PersonalInterestMask; 
          public byte? Age; 
          public byte? Zodiac; 
          public ushort? MatchOptionMask; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ProfileMatchResult : IDataSerializer
      {
          public int? RoleId; 
          public int? Level; 
          public int? Occupation; 
          public byte? Gender; 
          public float? Similarity; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetPlayerProfileDataArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetPlayerProfileDataRes : IDataSerializer
      {
          public int? RetCode; 
          public byte? Gender; 
          public PlayerProfileData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutPlayerProfileDataArg : IDataSerializer
      {
          public int? RoleId; 
          public PlayerProfileData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutPlayerProfileDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CrossPlayerData : IDataSerializer
      {
          public GRoleBase Base; 
          public GRoleStatus Status; 
          public GRolePocket Inventory; 
          public GRoleEquipment Equipment; 
          public GRoleStorehouse Storehouse; 
          public GRoleTask Task; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FetchPlayerDataArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public bool? Flag; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FetchPlayerDataRes : IDataSerializer
      {
          public int? RetCode; 
          public CrossPlayerData Data; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ActivatePlayerDataArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ActivatePlayerDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPlayerDataArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TouchPlayerDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelPlayerDataArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelPlayerDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FreezePlayerDataArg : IDataSerializer
      {
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public int? RemoteZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FreezePlayerDataRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerIdentityMatchArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? Ip; 
          public int? SrcZoneId; 
          public Octets Random; 
          public bool? Flag; 
          public uint? LocalSid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PlayerIdentityMatchRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets ISeckey; 
          public Octets OSeckey; 
          public Octets Account; 
          public User User; 
          public GRoleInfo RoleInfo; 
          public int? ZoneId; 
          public int? DistrictId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SavePlayerDataArg : IDataSerializer
      {
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public int? SrcZoneId; 
          public CrossPlayerData Data; 
          public bool? Flag; 
          public int? DataTimestamp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SavePlayerDataRes : IDataSerializer
      {
          public int? RetCode; 
          public int? NewRoleId; 
          public GRoleInfo RoleInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CrossInfoData : IDataSerializer
      {
          public int? RemoteRoleId; 
          public int? DataTimestamp; 
          public int? CrossTimestamp; 
          public int? SrcZoneId; 
          public int? Reserved1; 
          public int? Reserved2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUpdatePlayerCrossInfoArg : IDataSerializer
      {
          public int? RoleId; 
          public int? RemoteRoleId; 
          public int? UserID; 
          public int? RemoteZoneId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBUpdatePlayerCrossInfoRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockOrder : IDataSerializer
      {
          public uint? TId; 
          public int? Time; 
          public int? UserID; 
          public int? Price; 
          public int? Volume; 
          public bool? Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class StockPrice : IDataSerializer
      {
          public int? Price; 
          public int? Volume; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockBalanceArg : IDataSerializer
      {
          public uint? TId; 
          public int? UserID; 
          public int? AckVolume; 
          public int? AckMoney; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockBalanceRes : IDataSerializer
      {
          public int? RetCode; 
          public int? VolumeLeft; 
          public int? Cash; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockCommissionArg : IDataSerializer
      {
          public StockOrder Order; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockCommissionRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockCancelArg : IDataSerializer
      {
          public int? UserID; 
          public uint? TId; 
          public int? Volume; 
          public short? Result; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockCancelRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Cash; 
          public int? Money; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockTransactionArg : IDataSerializer
      {
          public int? UserID; 
          public int? RoleId; 
          public byte? WithDraw; 
          public int? Cash; 
          public int? Money; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockTransactionRes : IDataSerializer
      {
          public short? RetCode; 
          public int? Cash; 
          public int? Money; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockLoadArg : IDataSerializer
      {
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBStockLoadRes : IDataSerializer
      {
          public short? RetCode; 
          public Vector<StockOrder> Orders; 
          public Octets Handle; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GMember : IDataSerializer
      {
          public uint? RId; 
          public byte? Role; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GItem : IDataSerializer
      {
          public uint? Id; 
          public uint? Count; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionLog : IDataSerializer
      {
          public uint? RId; 
          public Octets Name; 
          public byte? Action; 
          public Vector<GItem> Items; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionStorehouse : IDataSerializer
      {
          public long? Money; 
          public Vector<GRoleInventory> Items; 
          public Vector<GFactionLog> Log; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionInfo : IDataSerializer
      {
          public uint? FId; 
          public Octets Name; 
          public byte? Level; 
          public GMember Master; 
          public Vector<GMember> Member; 
          public Octets Announce; 
          public Octets SysInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionBaseInfo : IDataSerializer
      {
          public uint? FId; 
          public Octets Name; 
          public byte? Level; 
          public short? MemNum; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionExtend : IDataSerializer
      {
          public int? JoinTime; 
          public int? Loyalty; 
          public int? LoginTime; 
          public int? Reserved1; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GUserFaction : IDataSerializer
      {
          public uint? RId; 
          public Octets Name; 
          public uint? FId; 
          public byte? Cls; 
          public byte? Role; 
          public Octets Delayexpel; 
          public Octets Extend; 
          public Octets NickName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionAlliance : IDataSerializer
      {
          public int? FId; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionHostile : IDataSerializer
      {
          public int? FId; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionRelationApply : IDataSerializer
      {
          public int? Type; 
          public int? FId; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionRelation : IDataSerializer
      {
          public int? FId; 
          public int? LastOpTime; 
          public Vector<GFactionAlliance> Alliance; 
          public Vector<GFactionHostile> Hostile; 
          public Vector<GFactionRelationApply> Apply; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionId : IDataSerializer
      {
          public uint? FId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFactionArg : IDataSerializer
      {
          public Octets Name; 
          public uint? RId; 
          public uint? FId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFactionRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddMemberArg : IDataSerializer
      {
          public uint? FId; 
          public uint? RId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddMemberRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets Name; 
          public byte? Cls; 
          public int? Level; 
          public int? Reputation; 
          public byte? ReincarnTimes; 
          public byte? Gender; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelMemberArg : IDataSerializer
      {
          public uint? FId; 
          public uint? RId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelMemberScheduleArg : IDataSerializer
      {
          public uint? FId; 
          public uint? RId; 
          public byte? Operation; 
          public int? Time; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UpdateUserFactionArg : IDataSerializer
      {
          public uint? FId; 
          public uint? RId; 
          public byte? Operation; 
          public byte? Role; 
          public short? Loyalty; 
          public Octets NickName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UpdateFactionArg : IDataSerializer
      {
          public uint? FId; 
          public byte? Type; 
          public byte? Level; 
          public Octets Announce; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DefFactionRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionUpgradeArg : IDataSerializer
      {
          public uint? FId; 
          public int? RoleId; 
          public uint? Money; 
          public byte? Level; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionUpgradeRes : IDataSerializer
      {
          public int? RetCode; 
          public int? Master; 
          public uint? Money; 
          public byte? Level; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionPromoteArg : IDataSerializer
      {
          public uint? FId; 
          public uint? Superior; 
          public uint? RoleId; 
          public byte? Suprole; 
          public byte? Newrole; 
          public int? Max; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionPromoteRes : IDataSerializer
      {
          public int? RetCode; 
          public byte? Suprole; 
          public byte? Newrole; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public GFactionInfo Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserFactionArg : IDataSerializer
      {
          public int? Reason; 
          public uint? RId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class UserFactionRes : IDataSerializer
      {
          public int? RetCode; 
          public GUserFaction Value; 
          public int? Level; 
          public int? Contrib; 
          public int? Reputation; 
          public byte? ReincarnTimes; 
          public byte? Gender; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFactionDetail : IDataSerializer
      {
          public uint? FId; 
          public Octets Name; 
          public byte? Level; 
          public uint? Master; 
          public Octets Announce; 
          public Octets SysInfo; 
          public Vector<FMemberInfo> Member; 
          public int? LastOpTime; 
          public Vector<GFactionAlliance> Alliance; 
          public Vector<GFactionHostile> Hostile; 
          public Vector<GFactionRelationApply> Apply; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionDetailRes : IDataSerializer
      {
          public int? RetCode; 
          public GFactionDetail Value; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DelFactionRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets FName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBVerifyMasterArg : IDataSerializer
      {
          public Octets Name; 
          public Octets Faction; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionAllianceApplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public int? EndTime; 
          public int? OpTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionAllianceReplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public byte? Agree; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionHostileApplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public int? EndTime; 
          public int? OpTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionHostileReplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public byte? Agree; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionRemoveRelationApplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public byte? Force; 
          public int? EndTime; 
          public int? OpTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionRemoveRelationReplyArg : IDataSerializer
      {
          public int? FId; 
          public int? DstFId; 
          public byte? Agree; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionRelationTimeoutArg : IDataSerializer
      {
          public int? Type; 
          public int? FId1; 
          public int? FId2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionRelationApplyTimeoutArg : IDataSerializer
      {
          public int? Type; 
          public int? FId1; 
          public int? FId2; 
          public int? EndTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionRelationRetcode : IDataSerializer
      {
          public int? RetCode; 
          public Octets FName1; 
          public Octets FName2; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FMemberInfo : IDataSerializer
      {
          public uint? RoleId; 
          public byte? Level; 
          public byte? Occupation; 
          public byte? FRoleId; 
          public ushort? Loginday; 
          public byte? OnlineStatus; 
          public Octets Name; 
          public Octets NickName; 
          public int? Contrib; 
          public byte? Delayexpel; 
          public int? ExpelTime; 
          public int? Reputation; 
          public byte? ReincarnTimes; 
          public byte? Gender; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GForceGlobalDataList : IDataSerializer
      {
          public Vector<GForceGlobalData> List; 
          public int? UpdateTime; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 
          public int? Reserved7; 
          public int? Reserved8; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GForceGlobalData : IDataSerializer
      {
          public int? ForceId; 
          public int? PlayerCount; 
          public int? Development; 
          public int? Construction; 
          public int? Activity; 
          public int? ActivityLevel; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 
          public int? Reserved7; 
          public int? Reserved8; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GForceGlobalDataBrief : IDataSerializer
      {
          public int? ForceId; 
          public int? PlayerCount; 
          public int? Development; 
          public int? Construction; 
          public int? Activity; 
          public int? ActivityLevel; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBForceLoadArg : IDataSerializer
      {
          public int? Nouse; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBForceLoadRes : IDataSerializer
      {
          public int? RetCode; 
          public GForceGlobalDataList List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutForceArg : IDataSerializer
      {
          public GForceGlobalDataList List; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutForceRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CountryBattleApplyEntry : IDataSerializer
      {
          public int? RoleId; 
          public int? MajorStrength; 
          public int? MinorStrength; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GCountryCapital : IDataSerializer
      {
          public int? CountryId; 
          public int? Worldtag; 
          public float? PosX; 
          public float? PosY; 
          public float? PosZ; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GCountryBattlePersonalScore : IDataSerializer
      {
          public int? RoleId; 
          public int? Cls; 
          public int? MinorStr; 
          public int? CombatTime; 
          public int? AttendTime; 
          public int? KillCount; 
          public int? DeathCount; 
          public int? ContributeVal; 
          public int? Damage; 
          public int? Hurt; 
          public int? DamageMinorStr; 
          public int? KillMinorStr; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GCountryBattleDomain : IDataSerializer
      {
          public int? Id; 
          public byte? Owner; 
          public byte? Challenger; 
          public bool? Status; 
          public byte? BattleConfigMask; 
          public int? Time; 
          public Vector<int> CountryPlayercnt; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCountryBattleBonusArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? Money; 
          public GRoleInventory Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBCountryBattleBonusRes : IDataSerializer
      {
          public short? RetCode; 
          public GMailHeader InformPlayer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GCountryBattleLimit : IDataSerializer
      {
          public byte? OccupationCntCeil; 
          public int? MinorStrFloor; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class PFactionInfo : IDataSerializer
      {
          public int? RoleId; 
          public uint? FactionId; 
          public byte? Factionrole; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionOPSyncInfo : IDataSerializer
      {
          public uint? PlayerMoney; 
          public int? PlayerSp; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionOPAddInfo : IDataSerializer
      {
          public int? RetCode; 
          public uint? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceFactionRoleDelArg : IDataSerializer
      {
          public int? RoleId; 
          public byte? ZoneId; 
          public uint? Faction; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AnnounceFactionRoleDelRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInviteArg : IDataSerializer
      {
          public int? RoleId; 
          public int? InvitedRoleId; 
          public uint? FactionId; 
          public Octets FactionName; 
          public Octets RoleName; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInviteRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KEKing : IDataSerializer
      {
          public int? RoleId; 
          public int? EndTime; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KECandidate : IDataSerializer
      {
          public int? RoleId; 
          public int? SerialNum; 
          public int? Deposit; 
          public int? Votes; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class KingElectionDetail : IDataSerializer
      {
          public KEKing King; 
          public Vector<KECandidate> CandidateList; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKELoadArg : IDataSerializer
      {
          public int? Nouse; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKELoadRes : IDataSerializer
      {
          public int? RetCode; 
          public KingElectionDetail Detail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKECandidateApplyArg : IDataSerializer
      {
          public int? RoleId; 
          public int? SerialNum; 
          public uint? ItemId; 
          public int? ItemNumber; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKECandidateApplyRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKECandidateConfirmArg : IDataSerializer
      {
          public Vector<int> CandidateList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKECandidateConfirmRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEVotingArg : IDataSerializer
      {
          public int? RoleId; 
          public uint? ItemId; 
          public int? ItemPos; 
          public int? ItemNumber; 
          public int? CandidateRoleId; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEVotingRes : IDataSerializer
      {
          public int? RetCode; 
          public GMailSyncData SyncData; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEKingConfirmArg : IDataSerializer
      {
          public KEKing King; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEKingConfirmRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEDeleteKingArg : IDataSerializer
      {
          public int? KingRoleId; 
          public int? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEDeleteKingRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEDeleteCandidateArg : IDataSerializer
      {
          public Vector<int> CandidateList; 
          public int? Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBKEDeleteCandidateRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TankBattlePlayerScoreInfo : IDataSerializer
      {
          public int? RoleId; 
          public int? KillCount; 
          public int? DeadCount; 
          public int? Score; 
          public int? Rank; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBTankBattleBonusArg : IDataSerializer
      {
          public int? RoleId; 
          public int? Rank; 
          public uint? Money; 
          public GRoleInventory Item; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBTankBattleBonusRes : IDataSerializer
      {
          public short? RetCode; 
          public GMailHeader InformPlayer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GGroupInfo : IDataSerializer
      {
          public byte? GId; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFriendInfo : IDataSerializer
      {
          public int? RId; 
          public byte? Cls; 
          public byte? GId; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFriendList : IDataSerializer
      {
          public Vector<GGroupInfo> Groups; 
          public Vector<GFriendInfo> Friends; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FriendListPair : IDataSerializer
      {
          public RoleId Key; 
          public GFriendList Value; 
          public Vector<GFriendExtInfo> ExtraInfo; 
          public Vector<GSendAUMailRecord> SendMailInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FriendListRes : IDataSerializer
      {
          public byte? RetCode; 
          public GFriendList Value; 
          public Vector<GFriendExtInfo> ExtraInfo; 
          public Vector<GSendAUMailRecord> SendMailInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GSendAUMailRecord : IDataSerializer
      {
          public int? RId; 
          public int? SendMailTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFriendExtInfo : IDataSerializer
      {
          public int? UId; 
          public int? RId; 
          public int? Level; 
          public int? LastloginTime; 
          public int? UpdateTime; 
          public byte? ReincarnationTimes; 
          public byte? Reserved0; 
          public short? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GFriendExtra : IDataSerializer
      {
          public Vector<GFriendExtInfo> FriendExtInfo; 
          public Vector<GSendAUMailRecord> SendaumailInfo; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFriendRqstArg : IDataSerializer
      {
          public int? SrcroleId; 
          public Octets SrcName; 
          public uint? DstlSId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class AddFriendRqstRes : IDataSerializer
      {
          public byte? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class Message : IDataSerializer
      {
          public byte? Channel; 
          public Octets SrcName; 
          public int? SrcroleId; 
          public Octets DstName; 
          public int? DstroleId; 
          public Octets Text; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GetMessageRes : IDataSerializer
      {
          public byte? RetCode; 
          public Vector<Message> Messages; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GChatMember : IDataSerializer
      {
          public int? RoleId; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRoomDetail : IDataSerializer
      {
          public ushort? RoomId; 
          public Octets Subject; 
          public Octets Owner; 
          public ushort? Capacity; 
          public bool? Status; 
          public Vector<GChatMember> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GChatRoom : IDataSerializer
      {
          public ushort? RoomId; 
          public Octets Subject; 
          public Octets Owner; 
          public ushort? Capacity; 
          public ushort? Number; 
          public bool? Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRefStore : IDataSerializer
      {
          public int? BonusAdd; 
          public int? BonusUsed; 
          public int? Referrer; 
          public int? ReferrerRoleId; 
          public int? BonusTotal1; 
          public int? BonusTotal2; 
          public int? BonusWithdraw; 
          public int? BonusWithdrawToday; 
          public int? MaxRoleLevel; 
          public Vector<Octets> Rolenames; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 
          public int? Reserved5; 
          public int? Reserved6; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GReferrer : IDataSerializer
      {
          public int? UserID; 
          public int? BonusAdd; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GReferral : IDataSerializer
      {
          public int? UserID; 
          public int? BonusTotal1; 
          public int? BonusTotal2; 
          public int? BonusWithdraw; 
          public int? BonusWithdrawToday; 
          public int? MaxRoleLevel; 
          public Vector<Octets> Rolenames; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ReferralBrief : IDataSerializer
      {
          public Vector<Octets> Rolenames; 
          public int? MaxLevel; 
          public int? BonusTotal1; 
          public int? BonusTotal2; 
          public int? BonusLeft; 
          public int? BonusAvail; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRefWithdrawTransArg : IDataSerializer
      {
          public int? RoleId; 
          public GReferrer Referrer; 
          public Vector<GReferral> Referrals; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRefGetReferralRes : IDataSerializer
      {
          public int? RetCode; 
          public GReferral Referral; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRefGetReferrerRes : IDataSerializer
      {
          public int? RetCode; 
          public GReferrer Referrer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRefUpdateReferralArg : IDataSerializer
      {
          public GReferral Referral; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRefUpdateReferrerArg : IDataSerializer
      {
          public GReferrer Referrer; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRewardItem : IDataSerializer
      {
          public int? RewardTime; 
          public int? RewardBonus; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GRewardStore : IDataSerializer
      {
          public int? ConsumePoints; 
          public int? BonusReward; 
          public Vector<GRewardItem> RewardList; 
          public int? Reserved1; 
          public int? Reserved2; 
          public int? Reserved3; 
          public int? Reserved4; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RewardItem : IDataSerializer
      {
          public int? RewardTime; 
          public int? RewardBonus; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetRewardArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGetRewardRes : IDataSerializer
      {
          public int? RetCode; 
          public GRewardStore Reward; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutConsumePointsArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? ConsumePoints; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBPutRewardBonusArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? BonusReward; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRewardMatureArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? BonusReward; 
          public Vector<GRewardItem> RewardList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRewardMatureRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBExchangeConsumePointsArg : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? ConsumePoints; 
          public Vector<GRewardItem> RewardList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBExchangeConsumePointsRes : IDataSerializer
      {
          public int? RetCode; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACQ : IDataSerializer
      {
          public int? QueryType; 
          public int? ZoneId; 
          public int? RoleId; 
          public int? XId; 
          public int? Timeout; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class IntData : IDataSerializer
      {
          public int? IntValue; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class OctetsData : IDataSerializer
      {
          public Octets OctetsValue; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACLogInfo : IDataSerializer
      {
          public int? Type; 
          public int? SubId; 
          public int? LogTime; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACCodeRes : IDataSerializer
      {
          public short? CodeId; 
          public int? Res; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACUserCodeRes : IDataSerializer
      {
          public short? Count; 
          public short? Type; 
          public Vector<ACCodeRes> Res; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACStackPattern : IDataSerializer
      {
          public int? Caller; 
          public int? Size; 
          public int? Pattern; 
          public int? Count; 
          public int? CountHd; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACPlatformInfo : IDataSerializer
      {
          public int? Id; 
          public int? MajorVersion; 
          public int? MinorVersion; 
          public int? BuildNumber; 
          public int? Count; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACCPUInfo : IDataSerializer
      {
          public short? Arch; 
          public short? Level; 
          public int? Ct; 
          public int? Count; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACMemInfo : IDataSerializer
      {
          public int? Ct; 
          public int? Count; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACAdapterInfo : IDataSerializer
      {
          public Octets Des; 
          public int? Count; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACMouseInfo : IDataSerializer
      {
          public int? LButtonFreq; 
          public int? RButtonFreq; 
          public int? MouseMovefreq; 
          public float? MouseMovevelo; 
          public Vector<IntData> GCounts; 
          public Vector<IntData> GTimes; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACThreadTime : IDataSerializer
      {
          public int? ThreadId; 
          public int? AllSecs; 
          public int? KernelSecs; 
          public int? UserSecs; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACProtocolStat : IDataSerializer
      {
          public int? Keepalive; 
          public int? GameDataSend; 
          public int? Acreport; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACOnlineStatus : IDataSerializer
      {
          public int? RoleId; 
          public int? Ip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ACOnlineStatus2 : IDataSerializer
      {
          public int? RoleId; 
          public int? UserID; 
          public int? Ip; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ForbidUserArg : IDataSerializer
      {
          public byte? Operation; 
          public int? GmUserId; 
          public int? Source; 
          public int? UserID; 
          public int? Time; 
          public Octets Reason; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class ForbidUserRes : IDataSerializer
      {
          public int? RetCode; 
          public GRoleForbid Forbid; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBAutolockSetArg : IDataSerializer
      {
          public int? UserID; 
          public Vector<GPair> AutoLock; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleImportBean : IDataSerializer
      {
          public long? UId; 
          public long? RoleId; 
          public Octets RoleName; 
          public byte? Gender; 
          public int? Race; 
          public int? Occupation; 
          public int? Level; 
          public Octets ExtInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class GroupBean : IDataSerializer
      {
          public int? GType; 
          public long? GroupId; 
          public Octets GroupName; 
          public Vector<long> FriendList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FriendImportBean : IDataSerializer
      {
          public int? ZoneId; 
          public long? RoleId; 
          public Vector<GroupBean> Friends; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TitleBean : IDataSerializer
      {
          public int? TitleId; 
          public Octets TitleName; 
          public Vector<long> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionImportBean : IDataSerializer
      {
          public int? FType; 
          public long? FactionId; 
          public Octets FactionName; 
          public Octets Announcement; 
          public Octets ExtInfo; 
          public Vector<TitleBean> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleInfoBean : IDataSerializer
      {
          public long? RoleId; 
          public Octets RoleName; 
          public byte? Gender; 
          public int? Race; 
          public int? Occupation; 
          public int? Level; 
          public Octets ExtInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleStatusBean : IDataSerializer
      {
          public bool? Status; 
          public Octets ExtInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleBean : IDataSerializer
      {
          public RoleInfoBean Info; 
          public RoleStatusBean Status; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleGroupBean : IDataSerializer
      {
          public int? GType; 
          public long? GroupId; 
          public Octets GroupName; 
          public Vector<RoleBean> Friends; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class RoleMsgBean : IDataSerializer
      {
          public long? Sender; 
          public Octets SenderName; 
          public long? Time; 
          public int? EmotionGroup; 
          public Octets Content; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionIDBean : IDataSerializer
      {
          public int? FType; 
          public long? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionInfoBean : IDataSerializer
      {
          public Octets FactionName; 
          public Octets Announcement; 
          public Octets ExtInfo; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionTitleBean : IDataSerializer
      {
          public int? TitleId; 
          public Octets TitleName; 
          public Vector<RoleBean> Titlemembers; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class FactionExt : IDataSerializer
      {
          public int? Level; 
          public int? Exp; 
          public int? FortressLvl; 
          public int? Health; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class CityWar : IDataSerializer
      {
          public Vector<GCity> CityList; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class TeamBean : IDataSerializer
      {
          public long? TeamId; 
          public long? Captain; 
          public Vector<long> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleListArg : IDataSerializer
      {
          public int? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleRelationArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRoleBase : IDataSerializer
      {
          public int? RoleId; 
          public Octets Name; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBRoleGroup : IDataSerializer
      {
          public int? GType; 
          public byte? Id; 
          public Octets Name; 
          public Vector<DBRoleBase> Friends; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleRelationRes : IDataSerializer
      {
          public int? RetCode; 
          public RoleBean Info; 
          public Vector<FactionIDBean> Factions; 
          public Vector<DBRoleGroup> Groups; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkFactionInfoArg : IDataSerializer
      {
          public uint? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBFactionMember : IDataSerializer
      {
          public DBRoleBase Info; 
          public int? Title; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkFactionInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public Octets Name; 
          public Octets Announce; 
          public Octets ExInfo; 
          public Vector<DBFactionMember> Members; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleStatusArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleStatusRes : IDataSerializer
      {
          public int? Status; 
          public long? ForbidTime; 
          public uint? UserID; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleInfoArg : IDataSerializer
      {
          public int? RoleId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class DBGameTalkRoleInfoRes : IDataSerializer
      {
          public int? RetCode; 
          public RoleInfoBean Info; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SNSRoleBrief : IDataSerializer
      {
          public int? Level; 
          public int? Exp; 
          public int? Sp; 
          public int? Level2; 
          public int? Reputation; 
          public int? Pp; 
          public int? Vitality; 
          public int? Energy; 
          public int? Strength; 
          public int? Agility; 
          public int? MaxHp; 
          public int? MaxMp; 
          public float? RunSpeed; 
          public int? Attack; 
          public int? DamageLow; 
          public int? DamageHigh; 
          public int? AttackSpeed; 
          public float? AttackRange; 
          public int? DamageMagicLow; 
          public int? DamageMagicHigh; 
          public int? Resistance0; 
          public int? Resistance1; 
          public int? Resistance2; 
          public int? Resistance3; 
          public int? Resistance4; 
          public int? Defense; 
          public int? Armor; 
          public int? CritRate; 
          public int? CritDamage; 
          public int? AttackDegree; 
          public int? DefendDegree; 
          public int? InvisibleDegree; 
          public int? AntiInvisibleDegree; 
          public int? SoulPower; 
          public uint? SkillsCRC; 
          public uint? EquipmentCRC; 
          public uint? PetcorralCRC; 
          public int? Spouse; 
          public int? FactionId; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SNSRoleSkills : IDataSerializer
      {
          public uint? CRC; 
          public Octets Skills; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SNSRoleEquipment : IDataSerializer
      {
          public uint? CRC; 
          public GRoleEquipment Equipment; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }
      

      public abstract class SNSRolePetCorral : IDataSerializer
      {
          public uint? CRC; 
          public Octets Petcorral; 


          public abstract DataStream Serialize(DataStream ds);
          public abstract bool TryDeserialize(DataStream ds);
      }