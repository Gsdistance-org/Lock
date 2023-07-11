using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Lock
{
    internal static class rntm
    {
        internal static List<UnLock> unlocks = new List<UnLock>() { };
        internal static Random rng = new Random();
        internal static string pass = "4";
        internal static string passcodec = "ENULL";
        internal static BigInteger layer = 0;
        internal static void NewCodec()
        {
            switch (rng.Next(3))
            {
                case 0:
                    {
                        passcodec = "SHA1";
                        break;
                    }
                case 1:
                    {
                        passcodec = "SHA256";
                        break;
                    }
                case 2:
                    {
                        passcodec = "SHA384";
                        break;
                    }
                case 3:
                    {
                        passcodec = "SHA512";
                        break;
                    }
                default:
                    {
                        passcodec = "NULL";
                        break;
                    }
            }
        }
        internal static string SelectCodec(string estring)
        {
            switch ('E' + passcodec)
            {
                case nameof(ESHA1):
                    {
                        return ESHA1(estring);
                    }
                case nameof( ESHA256 ):
                    {
                        return ESHA256( estring );
                    }
                case nameof( ESHA384 ):
                    {
                        return ESHA384( estring );
                    }
                case nameof( ESHA512 ):
                    {
                        return ESHA512( estring );
                    }
                case nameof( ENULL ):
                    {
                        return ENULL( estring );
                    }
                default:
                    {
                        return estring;
                    }
            }
        }

        private static string ENULL( string estring )
        {
            return estring;
        }
        private static string ESHA256( string estring )
        {
            return BitConverter.ToString( new SHA256Managed().ComputeHash( Encoding.UTF8.GetBytes( estring ) ) ).Replace( "-", string.Empty );
        }
        private static string ESHA1( string estring )
        {
            return BitConverter.ToString( new SHA1Managed().ComputeHash( Encoding.UTF8.GetBytes( estring ) ) ).Replace( "-", string.Empty );
        }
        private static string ESHA384( string estring )
        {
            return BitConverter.ToString( new SHA384Managed().ComputeHash( Encoding.UTF8.GetBytes( estring ) ) ).Replace( "-", string.Empty );
        }
        private static string ESHA512( string estring )
        {
            return BitConverter.ToString( new SHA512Managed().ComputeHash( Encoding.UTF8.GetBytes( estring ) ) ).Replace( "-", string.Empty );
        }
    }
}
