﻿using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ProcessCreationService {
    public class PCS {
        private TcpChannel _channel;
        private PCSService _pcsService;

        public PCS() {
            _channel = new TcpChannel(10000);
            ChannelServices.RegisterChannel(_channel, false);
            _pcsService = new PCSService();
            RemotingServices.Marshal(_pcsService, "PCSSERVICE", typeof(PCSService));
        }

        static void Main(string[] args) {
            Console.WriteLine("|========== Process Creation Service ==========|");
            PCS pcs = new PCS();

            Console.WriteLine("[QUIT to Exit]");

            while (true) {
                Console.Write("[COMMAND]");
                String command = Console.ReadLine();
                if (command.Equals("QUIT") || command.Equals("quit"))
                    break;
            }
        }
    }
}
