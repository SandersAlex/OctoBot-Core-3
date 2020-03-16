using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace OctoBot.Utils
{
   public static class FileUtilities
   {
      public static void WriteFile(string fileName, byte[] buffer)
      {
         if (fileName == null)
         {
            throw new ArgumentNullException("WriteFile(fileName)");
         }

         if (string.IsNullOrEmpty(fileName))
         {
            throw new ArgumentException("WriteFile(fileName)", "fileName string is empty");
         }

         if (buffer == null)
         {
            throw new ArgumentNullException("WriteFile(buffer)");
         }

         CreateBackupFile(fileName);

         using (var fileWriter = OpenForWrite(fileName))
         {
            fileWriter.Write(buffer, 0, buffer.Length);
         }
      }

      public static FileStream OpenForWrite(string fileName)
      {
         if (fileName == null)
         {
            throw new ArgumentNullException("OpenForWrite(file)");
         }

         if (string.IsNullOrEmpty(fileName))
         {
            throw new ArgumentException("OpenForWrite(file)", "file string is empty");
         }

         return OpenFile(fileName, delegate (string name)
         {
            return new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
         });
      }

      public static FileStream OpenForRead(string fileName)
      {
         if (fileName == null)
         {
            throw new ArgumentNullException("OpenForRead(file)");
         }

         if (string.IsNullOrEmpty(fileName))
         {
            throw new ArgumentException("OpenForRead(file)", "file string is empty");
         }

         return OpenFile(fileName, delegate (string name)
         {
            return new FileStream(name, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
         });
      }

      public static FileStream OpenForAppend(string fileName)
      {
         if (fileName == null)
         {
            throw new ArgumentNullException("OpenForAppend(file)");
         }

         if (string.IsNullOrEmpty(fileName))
         {
            throw new ArgumentException("OpenForAppend(file)", "file string is empty");
         }

         return OpenFile(fileName, delegate (string name)
         {
            return new FileStream(name, FileMode.Append, FileAccess.Write, FileShare.None);
         });
      }

      private delegate FileStream OpenFileHandler(string fileName);

      private static FileStream OpenFile(string fileName, OpenFileHandler openFileHandler)
      {
         var retries = 10;
         FileStream file;

         for (; ; )
         {
            try
            {
               file = openFileHandler(fileName);
               break;
            }

            catch (UnauthorizedAccessException)
            {
               if (--retries <= 0)
               {
                  throw;
               }
               Thread.Sleep(100);
            }
         }

         return file;
      }

      private static void CreateBackupFile(string file)
      {
         if (File.Exists(file))
         {
            var retries = 10;
            var backupFile = file + ".bak";

            for (; ; )
            {
               try
               {
                  File.Copy(file, backupFile, true);
                  break;
               }

               catch (UnauthorizedAccessException)
               {
                  if (--retries <= 0)
                  {
                     throw;
                  }
                  Thread.Sleep(100);
               }
            }
         }
      }
      public static string GetFileContents(string filePath)
      {
         StreamReader reader = new StreamReader(filePath);
         string content = reader.ReadToEnd();
         reader.Close();

         return content;
      }
      public static void SaveFileContents(string filePath, string contents)
      {
         using (FileStream fs = new FileStream(filePath, FileMode.Create))
         {
            // writing data in string
            byte[] info = new UTF8Encoding(true).GetBytes(contents);
            fs.Write(info, 0, info.Length);

            // writing data in bytes already
            byte[] data = new byte[] { 0x0 };
            fs.Write(data, 0, data.Length);
         }
      }

      public static bool FileExists(string[] arguments)
      {
         bool canContinue = true;

         if (arguments.Count<String>() < 1)
         {
            Console.WriteLine("Please specify at least one file path");
            canContinue = false;
         }

         foreach (var path in arguments)
         {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
               Console.WriteLine("{0} does not exist!", path);
               canContinue = false;
            }
         }

         return canContinue;
      }
      public static bool FileExists(string path)
      {
         FileInfo fi = new FileInfo(path);

         return fi.Exists;
      }
      public static long FileSize(string path)
      {
         long size = 0;

         FileInfo fi = new FileInfo(path);

         if (fi.Exists == true) size = fi.Length;

         return size;
      }
      public static bool DirectoryExits(string name)
      {
         DirectoryInfo di = new DirectoryInfo(name);

         return di.Exists;
      }
      public static void DirectoryMake(string name)
      {
         Directory.CreateDirectory(name);
      }
   }
}
