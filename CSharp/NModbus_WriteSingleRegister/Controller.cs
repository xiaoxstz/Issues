using NModbus;
using NModbus.Serial;
using System.IO.Ports;

namespace NModbusTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            byte slaveId = 1;
            Controller dM2C = new Controller();
            dM2C.Connect(serialNo: 11, BaudRate: 38400);

            Console.WriteLine("Started...");
            bool bSucceed = dM2C.SendPosNo(slaveId, 0);
            Console.WriteLine($"Completed. Succeed:{bSucceed}");
        }
    }

    public class Controller
    {
        private IModbusMaster? master;

        private SerialPort? port;

        public bool IsConnect { private set; get; } = false;

        public bool SendPosNo(byte slaveId, ushort PosNo)
        {
            ushort startAddress = 0x6002;
            ushort value = (ushort)(0x010 + PosNo);

            try
            {
                master.WriteSingleRegister(slaveId, startAddress, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return true;
        }

        public bool Connect(int serialNo, int BaudRate)
        {
            port = new SerialPort();
            port.PortName = $"COM{serialNo}";
            port.BaudRate = BaudRate;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.Open();

            this.IsConnect = port.IsOpen;
            if (this.IsConnect)
            {
                SerialPortAdapter adapter = new SerialPortAdapter(port);
                var factory = new ModbusFactory();

                master = factory.CreateRtuMaster(adapter);
                return true;
            }
            else return false;
        }
    }
}
