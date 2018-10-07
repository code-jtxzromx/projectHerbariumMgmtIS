using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace projectHerbariumMgmtIS.Model
{
    public class HerbariumImage
    {
        // Properties
        public string AccessionNumber { get; set; }
        public BitmapImage HerbariumSheet { get; set; }
        public string Tag { get; set; }

        // Constructor
        public HerbariumImage()
        {
            this.AccessionNumber = "";
            this.HerbariumSheet = new BitmapImage();
            this.Tag = "";
        }

        // Methods
        public async Task<BitmapImage> GetHerbariumSheet(bool isAcceptedDeposit, string depositNumber)
        {
            string table = isAcceptedDeposit ? "viewHerbariumPicture" : "viewReceivedDeposit";
            string field = isAcceptedDeposit ? "strAccessionNumber" : "strDepositNumber";

            byte[] blobImage = null;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT picHerbariumSheet " +
                                "FROM " + table + " " +
                                "WHERE " + field + " = @number");
            connection.addQueryParameter("@number", SqlDbType.VarChar, depositNumber);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                blobImage = sqlData[0] as byte[];
            }
            connection.closeResult();

            return await ConvertBinaryToPicture(blobImage);
        }

        public async Task<List<HerbariumImage>> GetHerbariumSheets(string AccessionNo)
        {
            List<HerbariumImage> images = new List<HerbariumImage>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, picHerbariumSheet, strTagDescription " +
                                "FROM viewHerbariumPicture " +
                                "WHERE strAccessionNumber = @number");
            connection.addQueryParameter("@number", SqlDbType.VarChar, AccessionNo);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                images.Add(new HerbariumImage()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    HerbariumSheet = await ConvertBinaryToPicture(sqlData[1] as byte[]),
                    Tag = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return images;
        }

        public async Task<BitmapImage> ConvertBinaryToPicture(byte[] blob)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(blob.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
        }

        public async Task<byte[]> ConvertPictureToBinary(Image picture)
        {
            BitmapImage source = picture.Source as BitmapImage;
            RandomAccessStreamReference streamReference = RandomAccessStreamReference.CreateFromUri(source.UriSource);
            IRandomAccessStreamWithContentType streamWithContent = await streamReference.OpenReadAsync();
            byte[] buffer = new byte[streamWithContent.Size];
            await streamWithContent.ReadAsync(buffer.AsBuffer(), (uint)streamWithContent.Size, InputStreamOptions.None);
            return buffer;
        }

        //public async Task<byte[]> ConvertPictureToBinary(Image picture)
        //{
        //    var bitmap = new RenderTargetBitmap();
        //    await bitmap.RenderAsync(picture);
        //    var bytes = (await bitmap.GetPixelsAsync()).ToArray();

        //    return bytes;
        //}

        //public async Task<byte[]> ConvertPictureToBinary(Image picture)
        //{
        //    BitmapImage source = picture.Source as BitmapImage;
        //    StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(source.UriSource);
        //    using (var inputStream = await file.OpenSequentialReadAsync())
        //    {
        //        var readStream = inputStream.AsStreamForRead();

        //        var byteArray = new byte[readStream.Length];
        //        await readStream.ReadAsync(byteArray, 0, byteArray.Length);
        //        return byteArray;
        //    }
        //}
    }
}
