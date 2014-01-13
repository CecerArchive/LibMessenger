using System;
using IHI.Server.Plugins;
using IHI.Server.Plugins.LibMessenger;
using IHI.Server.Rooms;
using IHI.Server.Rooms.Figure;

namespace IHI.Server.Habbos.Messenger
{
    public class Befriendable
    {
        #region Property: Id
        private readonly Func<int> _idGetter;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return _idGetter.Invoke();
            }
        }
        #endregion

        #region Property: DisplayName
        private Func<string> _displayNameGetter;
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayNameGetter.Invoke();
            }
        }
        #endregion

        #region Property: Motto
        private Func<string> _mottoGetter;
        /// <summary>
        /// 
        /// </summary>
        public string Motto
        {
            get
            {
                return _mottoGetter.Invoke();
            }
        }
        #endregion

        #region Property: Figure
        private Func<HabboFigure> _figureGetter;
        /// <summary>
        /// 
        /// </summary>
        public HabboFigure Figure
        {
            get
            {
                return _figureGetter.Invoke();
            }
        }
        #endregion

        #region Property: Position
        private Func<RoomPosition> _positionGetter;
        /// <summary>
        /// 
        /// </summary>
        public RoomPosition Position
        {
            get
            {
                return _positionGetter.Invoke();
            }
        }
        #endregion

        #region Property: LoggedIn
        private Func<bool> _loggedInGetter;
        /// <summary>
        /// 
        /// </summary>
        public bool LoggedIn
        {
            get
            {
                return _loggedInGetter.Invoke();
            }
        }
        #endregion

        #region Property: LastAccess
        private Func<DateTime> _lastAccessGetter;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastAccess
        {
            get
            {
                return _lastAccessGetter.Invoke();
            }
        }
        #endregion

        #region Blocking Properties
        #region Property: Stalkable
        /// <summary>
        /// 
        /// </summary>
        bool Stalkable
        {
            get;
            set;
        }
        #endregion
        #region Property: Requestable
        /// <summary>
        /// 
        /// </summary>
        bool Requestable
        {
            get;
            set;
        }
        #endregion
        #region Property: Inviteable
        /// <summary>
        /// 
        /// </summary>
        bool Inviteable
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region Method: Befriendable (Constructor)
        public Befriendable(Func<int> idGetter, Func<string> displayNameGetter, Func<string> mottoGetter, Func<HabboFigure> figureGetter, Func<RoomPosition> positionGetter, Func<bool> loggedInGetter, Func<DateTime> lastAccessGetter)
        {
            _idGetter = idGetter;
            _displayNameGetter = displayNameGetter;
            _mottoGetter = mottoGetter;
            _figureGetter = figureGetter;
            _positionGetter = positionGetter;
            _loggedInGetter = loggedInGetter;
            _lastAccessGetter = lastAccessGetter;
        }
        #endregion
    }
}
