﻿using System;
using JetBrains.Annotations;
using NetMQ.zmq;

namespace NetMQ
{
    /// <summary>
    /// This subclass of EventArgs contains a NetMQSocket,
    /// and IsReadyToReceive and IsReadyToSend flags to indicate whether ready to receive or send.
    /// </summary>
    public class NetMQSocketEventArgs : EventArgs
    {
        /// <summary>
        /// Create a new NetMQSocketEventArgs referencing the given socket.
        /// </summary>
        /// <param name="socket">the NetMQSocket that this is about</param>
        public NetMQSocketEventArgs([NotNull] NetMQSocket socket)
        {
            Socket = socket;
        }

        /// <summary>
        /// Initialise the ReceiveReady and SendReady flags from the given PollEvents value.
        /// </summary>
        /// <param name="events">a PollEvents value that indicates whether the socket is ready to send or receive without blocking</param>
        internal void Init(PollEvents events)
        {
            IsReadyToReceive = events.HasFlag(PollEvents.PollIn);
            IsReadyToSend = events.HasFlag(PollEvents.PollOut);
        }

        [NotNull]
        public NetMQSocket Socket { get; private set; }

        /// <summary>
        /// Get whether at least one message may be received by the socket without blocking.
        /// </summary>
        public bool IsReadyToReceive { get; private set; }

        /// <summary>
        /// Get whether at least one message may be sent by the socket without blocking.
        /// </summary>
        public bool IsReadyToSend { get; private set; }

        /// <summary>
        /// Get whether at least one message may be received by the socket without blocking.
        /// </summary>
        [Obsolete("Use IsReadyToReceive")]
        public bool ReceiveReady
        {
            get { return IsReadyToReceive; }
            private set { IsReadyToReceive = value; }
        }

         /// <summary>
        /// Get whether at least one message may be sent by the socket without blocking.
        /// </summary>
        [Obsolete("Use IsReadyToSend")]
        public bool SendReady
        {
            get { return IsReadyToSend; }
            private set { IsReadyToSend = value; }
        }
    }
}
