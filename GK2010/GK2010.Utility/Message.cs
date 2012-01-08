using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Utility
{
   public class Message
    {
        public Message()
        {
            _state = State.Success;
            _msg = string.Empty;
            _data = null;
        }

        private State _state;
        private string _msg;
        private Object _data;

        /// <summary>
        /// 操作状态
        /// </summary>
        public State State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public Object Data
        {
            set { _data = value; }
            get { return _data; }
        }
    }
}
