﻿//
//	Generated by ProtocolBuffer
//	- a pure c# code generation implementation of protocol buffers
//

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ProtocolBuffers;

namespace ExampleNamespace
{

	public interface IMyMessageV1
	{
		int FieldA { get; set; }
	}

	public class MyMessageV1 : IMyMessageV1
	{
		public int FieldA { get; set; }

		public MyMessageV1()
		{
		}
		public static IMyMessageV1 Read(Stream stream)
		{
			return Read(stream, new MyMessageV1());
		}
		public static IMyMessageV1 Read(byte[] buffer)
		{
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, new MyMessageV1());
		}
		public static IMyMessageV1 Read(byte[] buffer, IMyMessageV1 instance)
		{
			if(instance == null)
				instance = new MyMessageV1();
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, instance);
		}
		public static IMyMessageV1 Read (Stream stream, IMyMessageV1 instance)
		{
			while (true)
			{
				Key key = null;
				try {
					key = ProtocolParser.ReadKey (stream);
				} catch (InvalidDataException) {
					break;
				}
				
				switch (key.Field) {
				case 1:
					instance.FieldA = (int)ProtocolParser.ReadUInt32(stream);
					break;
				default:
					ProtocolParser.SkipKey(stream, key);
					break;
				}
			}
			return instance;
		}
		public static void Write(Stream stream, IMyMessageV1 instance)
		{
			ProtocolParser.WriteKey(stream, new Key(1, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldA);
		}

	}

	public interface IMyMessageV2
	{
		int FieldA { get; set; }
		double FieldB { get; set; }
		float FieldC { get; set; }
		int FieldD { get; set; }
		long FieldE { get; set; }
		uint FieldF { get; set; }
		ulong FieldG { get; set; }
		int FieldH { get; set; }
		long FieldI { get; set; }
		uint FieldJ { get; set; }
		ulong FieldK { get; set; }
		int FieldL { get; set; }
		long FieldM { get; set; }
		bool FieldN { get; set; }
		string FieldO { get; set; }
		byte[] FieldP { get; set; }
		MyMessageV2.MyEnum FieldQ { get; set; }
		MyMessageV2.MyEnum FieldR { get; set; }
		[Obsolete]
		string Dummy { get; set; }
		List<uint> FieldS { get; set; }
		List<uint> FieldT { get; set; }
		ITheirMessage FieldU { get; set; }
		IList<ITheirMessage> FieldV { get; set; }
	}

	public class MyMessageV2 : IMyMessageV2
	{
		public enum MyEnum
		{
			ETest1 = 0,
			ETest2 = 3,
			ETest3 = 2,
		}

		public int FieldA { get; set; }
		public double FieldB { get; set; }
		public float FieldC { get; set; }
		public int FieldD { get; set; }
		public long FieldE { get; set; }
		public uint FieldF { get; set; }
		public ulong FieldG { get; set; }
		public int FieldH { get; set; }
		public long FieldI { get; set; }
		public uint FieldJ { get; set; }
		public ulong FieldK { get; set; }
		public int FieldL { get; set; }
		public long FieldM { get; set; }
		public bool FieldN { get; set; }
		public string FieldO { get; set; }
		public byte[] FieldP { get; set; }
		public MyMessageV2.MyEnum FieldQ { get; set; }
		public MyMessageV2.MyEnum FieldR { get; set; }
		public string Dummy { get; set; }
		public List<uint> FieldS { get; set; }
		public List<uint> FieldT { get; set; }
		public ITheirMessage FieldU { get; set; }
		public IList<ITheirMessage> FieldV { get; set; }

		public MyMessageV2()
		{
			this.FieldR = MyMessageV2.MyEnum.ETest2;
			this.FieldS = new List<uint>();
			this.FieldT = new List<uint>();
			this.FieldV = new List<ITheirMessage>();
		}
		public static IMyMessageV2 Read(Stream stream)
		{
			return Read(stream, new MyMessageV2());
		}
		public static IMyMessageV2 Read(byte[] buffer)
		{
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, new MyMessageV2());
		}
		public static IMyMessageV2 Read(byte[] buffer, IMyMessageV2 instance)
		{
			if(instance == null)
				instance = new MyMessageV2();
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, instance);
		}
		public static IMyMessageV2 Read (Stream stream, IMyMessageV2 instance)
		{
			BinaryReader br = new BinaryReader (stream);
			while (true)
			{
				Key key = null;
				try {
					key = ProtocolParser.ReadKey (stream);
				} catch (InvalidDataException) {
					break;
				}
				
				switch (key.Field) {
				case 1:
					instance.FieldA = (int)ProtocolParser.ReadUInt32(stream);
					break;
				case 2:
					instance.FieldB = br.ReadDouble ();
					break;
				case 3:
					instance.FieldC = br.ReadSingle ();
					break;
				case 4:
					instance.FieldD = (int)ProtocolParser.ReadUInt32(stream);
					break;
				case 5:
					instance.FieldE = (long)ProtocolParser.ReadUInt64(stream);
					break;
				case 6:
					instance.FieldF = ProtocolParser.ReadUInt32(stream);
					break;
				case 7:
					instance.FieldG = ProtocolParser.ReadUInt64(stream);;
					break;
				case 8:
					instance.FieldH = ProtocolParser.ReadSInt32(stream);;
					break;
				case 9:
					instance.FieldI = ProtocolParser.ReadSInt64(stream);;
					break;
				case 10:
					instance.FieldJ = br.ReadUInt32 ();
					break;
				case 11:
					instance.FieldK = br.ReadUInt64 ();
					break;
				case 12:
					instance.FieldL = br.ReadInt32 ();
					break;
				case 13:
					instance.FieldM = br.ReadInt64 ();
					break;
				case 14:
					instance.FieldN = ProtocolParser.ReadBool(stream);
					break;
				case 15:
					instance.FieldO = ProtocolParser.ReadString(stream);
					break;
				case 16:
					instance.FieldP = ProtocolParser.ReadBytes(stream);
					break;
				case 17:
					instance.FieldQ = (MyMessageV2.MyEnum)ProtocolParser.ReadUInt32(stream);
					break;
				case 18:
					instance.FieldR = (MyMessageV2.MyEnum)ProtocolParser.ReadUInt32(stream);
					break;
				case 19:
					instance.Dummy = ProtocolParser.ReadString(stream);
					break;
				case 20:
					instance.FieldS.Add(ProtocolParser.ReadUInt32(stream));
					break;
				case 21:
					using(MemoryStream ms21 = new MemoryStream(ProtocolParser.ReadBytes(stream)))
					{
						while(true)
						{
							if(ms21.Position == ms21.Length)
								break;
							instance.FieldT.Add(ProtocolParser.ReadUInt32(ms21));
						}
					}
					break;
				case 22:
					instance.FieldU = TheirMessage.Read(ProtocolParser.ReadBytes(stream), instance.FieldU);
					break;
				case 23:
					instance.FieldV.Add(TheirMessage.Read(ProtocolParser.ReadBytes(stream)));
					break;
				default:
					ProtocolParser.SkipKey(stream, key);
					break;
				}
			}
			return instance;
		}
		public static void Write(Stream stream, IMyMessageV2 instance)
		{
			BinaryWriter bw = new BinaryWriter(stream);
			ProtocolParser.WriteKey(stream, new Key(1, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldA);
			ProtocolParser.WriteKey(stream, new Key(2, Wire.Fixed64));
			bw.Write(instance.FieldB);
			ProtocolParser.WriteKey(stream, new Key(3, Wire.Fixed32));
			bw.Write(instance.FieldC);
			ProtocolParser.WriteKey(stream, new Key(4, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldD);
			ProtocolParser.WriteKey(stream, new Key(5, Wire.Varint));
			ProtocolParser.WriteUInt64(stream, (ulong)instance.FieldE);
			ProtocolParser.WriteKey(stream, new Key(6, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, instance.FieldF);
			ProtocolParser.WriteKey(stream, new Key(7, Wire.Varint));
			ProtocolParser.WriteUInt64(stream, instance.FieldG);
			ProtocolParser.WriteKey(stream, new Key(8, Wire.Varint));
			ProtocolParser.WriteSInt32(stream, instance.FieldH);
			ProtocolParser.WriteKey(stream, new Key(9, Wire.Varint));
			ProtocolParser.WriteSInt64(stream, instance.FieldI);
			ProtocolParser.WriteKey(stream, new Key(10, Wire.Fixed32));
			bw.Write(instance.FieldJ);
			ProtocolParser.WriteKey(stream, new Key(11, Wire.Fixed64));
			bw.Write(instance.FieldK);
			ProtocolParser.WriteKey(stream, new Key(12, Wire.Fixed32));
			bw.Write(instance.FieldL);
			ProtocolParser.WriteKey(stream, new Key(13, Wire.Fixed64));
			bw.Write(instance.FieldM);
			ProtocolParser.WriteKey(stream, new Key(14, Wire.Varint));
			ProtocolParser.WriteBool(stream, instance.FieldN);
			if(instance.FieldO == null)
				throw new ArgumentNullException("FieldO", "Required by proto specification.");
			ProtocolParser.WriteKey(stream, new Key(15, Wire.LengthDelimited));
			ProtocolParser.WriteString(stream, instance.FieldO);
			if(instance.FieldP == null)
				throw new ArgumentNullException("FieldP", "Required by proto specification.");
			ProtocolParser.WriteKey(stream, new Key(16, Wire.LengthDelimited));
			ProtocolParser.WriteBytes(stream, instance.FieldP);
			ProtocolParser.WriteKey(stream, new Key(17, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldQ);
			ProtocolParser.WriteKey(stream, new Key(18, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldR);
			if(instance.Dummy != null)
			{
				ProtocolParser.WriteKey(stream, new Key(19, Wire.LengthDelimited));
				ProtocolParser.WriteString(stream, instance.Dummy);
			}
			foreach (uint i20 in instance.FieldS)
			{
				ProtocolParser.WriteKey(stream, new Key(20, Wire.Varint));
				ProtocolParser.WriteUInt32(stream, i20);
			}
			ProtocolParser.WriteKey(stream, new Key(21, Wire.LengthDelimited));
			using(MemoryStream ms21 = new MemoryStream())
			{
				foreach (uint i21 in instance.FieldT)
				{
					ProtocolParser.WriteUInt32(ms21, i21);
				}
				ProtocolParser.WriteBytes(stream, ms21.ToArray());
			}
			if(instance.FieldU != null)
			{
				ProtocolParser.WriteKey(stream, new Key(22, Wire.LengthDelimited));
				using(MemoryStream ms22 = new MemoryStream())
				{
					TheirMessage.Write(ms22, instance.FieldU);
					ProtocolParser.WriteBytes(stream, ms22.ToArray());
				}
			}
			foreach (TheirMessage i23 in instance.FieldV)
			{
				ProtocolParser.WriteKey(stream, new Key(23, Wire.LengthDelimited));
				using(MemoryStream ms23 = new MemoryStream())
				{
					TheirMessage.Write(ms23, i23);
					ProtocolParser.WriteBytes(stream, ms23.ToArray());
				}
			}
		}

	}

	public interface ITheirMessage
	{
		int FieldA { get; set; }
	}

	public class TheirMessage : ITheirMessage
	{
		public int FieldA { get; set; }

		public TheirMessage()
		{
		}
		public static ITheirMessage Read(Stream stream)
		{
			return Read(stream, new TheirMessage());
		}
		public static ITheirMessage Read(byte[] buffer)
		{
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, new TheirMessage());
		}
		public static ITheirMessage Read(byte[] buffer, ITheirMessage instance)
		{
			if(instance == null)
				instance = new TheirMessage();
			using(MemoryStream ms = new MemoryStream(buffer))
				return Read(ms, instance);
		}
		public static ITheirMessage Read (Stream stream, ITheirMessage instance)
		{
			while (true)
			{
				Key key = null;
				try {
					key = ProtocolParser.ReadKey (stream);
				} catch (InvalidDataException) {
					break;
				}
				
				switch (key.Field) {
				case 1:
					instance.FieldA = (int)ProtocolParser.ReadUInt32(stream);
					break;
				default:
					ProtocolParser.SkipKey(stream, key);
					break;
				}
			}
			return instance;
		}
		public static void Write(Stream stream, ITheirMessage instance)
		{
			ProtocolParser.WriteKey(stream, new Key(1, Wire.Varint));
			ProtocolParser.WriteUInt32(stream, (uint)instance.FieldA);
		}

	}

}
#region ProtocolParser.cs

// 
//	Read/Write string and byte arrays 
// 
namespace ProtocolBuffers
{
	public static partial class ProtocolParser
	{
		
		public static string ReadString (Stream stream)
		{
			return Encoding.UTF8.GetString (ReadBytes (stream));
		}
		
		public static byte[] ReadBytes (Stream stream)
		{
			//VarInt length
			uint length = ReadUInt32 (stream);
			
			//Bytes
			byte[] buffer = new byte[length];
			stream.Read (buffer, 0, buffer.Length);
			return buffer;
		}
		
		public static void WriteString (Stream stream, string val)
		{
			WriteBytes (stream, Encoding.UTF8.GetBytes (val));
		}
		
		public static void WriteBytes (Stream stream, byte[] val)
		{
			WriteUInt32 (stream, (uint)val.Length);
			stream.Write (val, 0, val.Length);
		}
		
	}
}

#endregion
#region ProtocolParserFixed.cs
//
//	This file contain references on how to write and read
//	fixed integers and float/double.
//	

namespace ProtocolBuffers
{
	public static partial class ProtocolParser
	{
		#region Fixed Int
		
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static ulong ReadFixed64 (BinaryReader reader)
		{
			return reader.ReadUInt64 ();
		}

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static long ReadSFixed64 (BinaryReader reader)
		{
			return reader.ReadInt64 ();
		}
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static uint ReadFixed32 (BinaryReader reader)
		{
			return reader.ReadUInt32 ();
		}

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static int ReadSFixed32 (BinaryReader reader)
		{
			return reader.ReadInt32 ();
		}
		
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteFixed64 (BinaryWriter writer, ulong val)
		{
			writer.Write (val);
		}

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteSFixed64 (BinaryWriter writer, long val)
		{
			writer.Write (val);
		}
		
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteFixed32 (BinaryWriter writer, uint val)
		{
			writer.Write (val);
		}

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteSFixed32 (BinaryWriter writer, int val)
		{
			writer.Write (val);
		}
		
		#endregion
		
		#region Fixed: float, double

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static float ReadFloat (BinaryReader reader)
		{
			return reader.ReadSingle ();
		}
		
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static double ReadDouble (BinaryReader reader)
		{
			return reader.ReadDouble ();
		}

		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteFloat (BinaryWriter writer, float val)
		{
			writer.Write (val);
		}
		
		/// <summary>
		/// Only for reference
		/// </summary>
		[Obsolete("Only for reference")]
		public static void WriteDouble (BinaryWriter writer, double val)
		{
			writer.Write (val);
		}


		#endregion
		
	}
}

#endregion
#region ProtocolParserKey.cs
//
//	Reader/Writer for field key
//

namespace ProtocolBuffers
{
	public enum Wire
	{
		Varint = 0,		//int32, int64, uint32, uint64, sint32, sint64, bool, enum
		Fixed64 = 1,	//fixed64, sfixed64, double
		LengthDelimited = 2,	//string, bytes, embedded messages, packed repeated fields
		//Start = 3, 		//	groups (deprecated)
		//End = 4,		//	groups (deprecated)
		Fixed32 = 5,	//32-bit	fixed32, sfixed32, float
	}

	public class Key
	{
		public uint Field { get; set; }

		public Wire WireType { get; set; }
		
		public Key (uint field, Wire wireType)
		{
			this.Field = field;
			this.WireType = wireType;				
		}
	}
	
	public static partial class ProtocolParser
	{
		
		public static Key ReadKey (Stream stream)
		{
			uint n = ReadUInt32 (stream);
			return new Key (n >> 3, (Wire)(n & 0x07));
		}
		
		public static void WriteKey (Stream stream, Key key)
		{
			uint n = (key.Field << 3) | ((uint)key.WireType);
			WriteUInt32 (stream, n);
		}
		
		public static void SkipKey(Stream stream, Key key)
		{
			switch (key.WireType) {
			case Wire.Fixed32:
				stream.Seek (4, SeekOrigin.Current);
				return;
			case Wire.Fixed64:
				stream.Seek (8, SeekOrigin.Current);
				return;
			case Wire.LengthDelimited:
				stream.Seek (ProtocolParser.ReadUInt32 (stream), SeekOrigin.Current);
				return;
			case Wire.Varint:
				ProtocolParser.ReadSkipVarInt (stream);
				return;
			default:
				throw new NotImplementedException ();
			}
		}
	}
}

#endregion
#region ProtocolParserVarInt.cs

namespace ProtocolBuffers
{
	public static partial class ProtocolParser
	{
		/// <summary>
		/// Reads past a varint for an unknown field.
		/// </summary>
		public static void ReadSkipVarInt (Stream stream)
		{
			while (true) {
				int b = stream.ReadByte ();
				if (b < 0)
					throw new InvalidDataException ("Stream ended too early");
				
				if ((b & 0x80) == 0)
					return; //end of varint
			}
		}
		
		#region VarInt: int32, uint32, sint32
		
		[Obsolete("Use (int)ReadUInt32 (stream);")]
		/// <summary>
		/// Since the int32 format is inefficient for negative numbers we have avoided to imlplement.
		/// The same functionality can be achieved using: (int)ReadUInt32 (stream);
		/// </summary>
		public static int ReadInt32 (Stream stream)
		{
			throw new NotImplementedException ("Use (int)ReadUInt32 (stream);");
		}
		
		[Obsolete("Use WriteUInt32 (stream, (uint)val);")]
		/// <summary>
		/// Since the int32 format is inefficient for negative numbers we have avoided to imlplement.
		/// The same functionality can be achieved using: WriteUInt32 (stream, (uint)val);
		/// </summary>
		public static void WriteInt32 (Stream stream, int val)
		{
			throw new NotImplementedException ("Use WriteUInt32 (stream, (uint)val);");
		}
		
		public static int ReadSInt32 (Stream stream)
		{
			uint uval = ReadUInt32 (stream);
			return (int)((uval >> 1) | (uval << 31));
			
		}
		
		public static void WriteSInt32 (Stream stream, int val)
		{
			uint uval = (uint)val;
			WriteUInt32 (stream, (uval << 1) | (uval >> 31));
		}

		public static uint ReadUInt32 (Stream stream)
		{
			int b;
			uint val = 0;
			
			for (int n = 0; n < 5; n++) {
				b = stream.ReadByte ();
				if (b < 0)
					throw new InvalidDataException ("Stream ended too early");
				
				//Check that it fits in 32 bits
				if ((n == 4) && (b & 0xF0) != 0)
					throw new InvalidDataException ("Got larger VarInt than 32bit unsigned");
				//End of check
				
				if ((b & 0x80) == 0)
					return val | (uint)(b << (7 * n));
				
				val |= (uint)(b & 0x7F) << (7 * n);
			}
			
			throw new InvalidDataException ("Got larger VarInt than 32bit unsigned");
		}
		
		public static void WriteUInt32 (Stream stream, uint val)
		{
			byte[] buffer = new byte[5];
			int count = 0;
			
			while (true) {
				buffer [count] = (byte)(val & 0x7F);
				val = val >> 7;
				if (val == 0)
					break;
				
				buffer [count] |= 0x80;
				
				count += 1;
			}
			
			stream.Write (buffer, 0, count + 1);
		}
		
		#endregion
		
		#region VarInt: int64, uint64, sint64
		
		[Obsolete("Use (long)ReadUInt64 (stream); instead")]
		/// <summary>
		/// Since the int64 format is inefficient for negative numbers we have avoided to implement it.
		/// The same functionality can be achieved using: (long)ReadUInt64 (stream);
		/// </summary>
		public static int ReadInt64 (Stream stream)
		{
			throw new NotImplementedException ("Use (int)ReadUInt64 (stream); instead");
		}
		
		[Obsolete("Use WriteUInt64 (stream, (ulong)val); instead")]
		/// <summary>
		/// Since the int64 format is inefficient for negative numbers we have avoided to implement.
		/// The same functionality can be achieved using: WriteUInt64 (stream, (ulong)val);
		/// </summary>
		public static void WriteInt64 (Stream stream, int val)
		{
			throw new NotImplementedException ("Use WriteUInt64 (stream, (ulong)val); instead");
		}

		public static long ReadSInt64 (Stream stream)
		{
			ulong uval = ReadUInt64 (stream);
			return (long)((uval >> 1) | (uval << 63));
			
		}
		
		public static void WriteSInt64 (Stream stream, long val)
		{
			ulong uval = (ulong)val;
			WriteUInt64 (stream, (uval << 1) | (uval >> 63));
		}

		public static ulong ReadUInt64 (Stream stream)
		{
			int b;
			ulong val = 0;
			
			for (int n = 0; n < 10; n++) {
				b = stream.ReadByte ();
				if (b < 0)
					throw new InvalidDataException ("Stream ended too early");
				
				//Check that it fits in 64 bits
				if ((n == 9) && (b & 0xFE) != 0)
					throw new InvalidDataException ("Got larger VarInt than 64 bit unsigned");
				//End of check
				
				if ((b & 0x80) == 0)
					return val | (ulong)(b << (7 * n));
				
				val |= (ulong)(b & 0x7F) << (7 * n);
			}
			
			throw new InvalidDataException ("Got larger VarInt than 64 bit unsigned");
		}
		
		public static void WriteUInt64 (Stream stream, ulong val)
		{
			byte[] buffer = new byte[10];
			int count = 0;
			
			while (true) {
				buffer [count] = (byte)(val & 0x7F);
				val = val >> 7;
				if (val == 0)
					break;
				
				buffer [count] |= 0x80;
				
				count += 1;
			}
			
			stream.Write (buffer, 0, count + 1);
		}
		
		#endregion
		
		#region Varint: bool
		
		public static bool ReadBool (Stream stream)
		{
			int b = stream.ReadByte ();
			if (b < 0)
				throw new InvalidDataException ("Stream ended too early");
			if (b == 1)
				return true;
			if (b == 0)
				return false;
			throw new InvalidDataException ("Invalid boolean value");
		}
		
		public static void WriteBool (Stream stream, bool val)
		{
			stream.WriteByte (val ? (byte)1 : (byte)0);
		}
		
		#endregion
	}
}
#endregion
