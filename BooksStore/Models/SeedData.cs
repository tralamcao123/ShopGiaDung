using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BooksStoreDbContext context =
            app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < BooksStoreDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new Book
                {
                    hinhanh = " https://meta.vn/Data/image/2021/03/11/quat-dung-senko-sai-canh-dcn1806-5-canh-65w.jpg",
                    Title = "Quạt lỡ Senko",
                    Description = "Siêu tiết kiệm điện",
                    Genre = "Hàng Hot",
                    Price = 11.98m
                },
                new Book
                {
                    hinhanh = " https://cdn.tgdd.vn/Products/Images/9418/237690/237690-600x600.jpg",
                    Title = "Nồi chiên không dầu Kalite 10 lít",
                    Description = "Không gian rộng rãi để bạn thoải mái nấu mọi thứ",
                    Genre = "Còn Hàng",
                    Price = 17.46m
                },
                new Book
                {
                    hinhanh = " https://cdn.nguyenkimmall.com/images/detailed/643/10038489-may-loc-nuoc-karofi-megaton-10-loi-m-i2210-uh-2.jpg",
                    Title = "Máy lọc nước Karofi Megaton 10 lõi",
                    Description = "Lọc sạch 99,9% các vi khuẩn độc hại trong nước ",
                    Genre = "Cháy Hàng",
                    Price = 13.41m
                },

                new Book
                {
                    hinhanh = " https://quatboss.vn/medias/e52/images/2021/11/s106.jpg",
                    Title = "Quạt điều hòa Boss S106",
                    Description = "Đem lại cho gia đình bạn một không khí mát mẻ",
                    Genre = "Hàng Cao Cấp",
                    Price = 18.69m
                },
                new Book
                {
                    hinhanh = "https://salt.tikicdn.com/ts/tmp/8e/47/1b/7a3085c57cfd5c579f170cd335be8bb6.jpg",
                    Title = "Máy xay sinh tố Sunhouse SHD5112",
                    Description = "Thích hợp nhiều tính năng trong một sản phẩm",
                    Genre = "Ngưng Kinh Doanh",
                    Price = 31.26m
                }
                );

                context.SaveChanges();
            }
        }
    }
}