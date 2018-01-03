-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 28, 2017 at 01:39 AM
-- Server version: 10.1.22-MariaDB
-- PHP Version: 7.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `banmayanh`
--

-- --------------------------------------------------------

--
-- Table structure for table `chitietdondathang`
--

CREATE TABLE `chitietdondathang` (
  `MaChiTietDonDatHang` int(11) UNSIGNED NOT NULL,
  `MaDonDatHang` int(11) DEFAULT NULL,
  `MaSP` int(11) DEFAULT NULL,
  `SoLuong` int(11) DEFAULT NULL,
  `GiaBan` bigint(20) DEFAULT NULL,
  `TongTien` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `chitietdondathang`
--

INSERT INTO `chitietdondathang` (`MaChiTietDonDatHang`, `MaDonDatHang`, `MaSP`, `SoLuong`, `GiaBan`, `TongTien`) VALUES
(10, 6, 6, 1, 12029000, 12029000),
(11, 6, 7, 1, 10359000, 10359000),
(12, 6, 20, 1, 15948000, 15948000),
(13, 7, 13, 1, 24289000, 24289000),
(14, 7, 3, 1, 13500000, 13500000),
(15, 7, 28, 1, 219000, 219000),
(16, 7, 29, 1, 1570000, 1570000);

-- --------------------------------------------------------

--
-- Table structure for table `dondathang`
--

CREATE TABLE `dondathang` (
  `MaDonDatHang` int(10) UNSIGNED NOT NULL,
  `NgayLap` datetime NOT NULL,
  `MaTK` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `TongThanhTien` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `dondathang`
--

INSERT INTO `dondathang` (`MaDonDatHang`, `NgayLap`, `MaTK`, `TongThanhTien`) VALUES
(6, '2017-11-27 18:58:28', '1', '38336000'),
(7, '2017-11-27 19:01:08', '1', '39578000');

-- --------------------------------------------------------

--
-- Table structure for table `hangsx`
--

CREATE TABLE `hangsx` (
  `MaHangSX` int(11) NOT NULL,
  `TenHangSX` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `hangsx`
--

INSERT INTO `hangsx` (`MaHangSX`, `TenHangSX`) VALUES
(1, 'Fujifilm'),
(2, 'Sony '),
(3, 'Canon '),
(4, 'Nikon '),
(5, 'Olympus '),
(6, 'Panasonic '),
(7, 'Khác');

-- --------------------------------------------------------

--
-- Table structure for table `loaisanpham`
--

CREATE TABLE `loaisanpham` (
  `MaLoaiSP` int(11) NOT NULL,
  `TenLoaiSP` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `loaisanpham`
--

INSERT INTO `loaisanpham` (`MaLoaiSP`, `TenLoaiSP`) VALUES
(1, 'Máy ảnh không gương lật'),
(2, 'Máy ảnh DSLR'),
(3, 'Máy Ảnh Số Du Lịch'),
(4, 'Máy Ảnh chụp lấy ngay'),
(5, 'Máy Ảnh MINI'),
(6, 'Khác');

-- --------------------------------------------------------

--
-- Table structure for table `sanpham`
--

CREATE TABLE `sanpham` (
  `MaSP` int(11) NOT NULL,
  `TenSP` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `GiaSP` int(11) DEFAULT NULL,
  `SoLuotXem` int(11) DEFAULT NULL,
  `SoLuongBan` int(11) DEFAULT NULL,
  `ngaynhap` date NOT NULL,
  `MoTa` text COLLATE utf8_unicode_ci,
  `ChiTiet` text COLLATE utf8_unicode_ci,
  `XuatXu` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MaLoaiSP` int(11) DEFAULT NULL,
  `MaHangSX` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `sanpham`
--

INSERT INTO `sanpham` (`MaSP`, `TenSP`, `GiaSP`, `SoLuotXem`, `SoLuongBan`, `ngaynhap`, `MoTa`, `ChiTiet`, `XuatXu`, `MaLoaiSP`, `MaHangSX`) VALUES
(1, 'Fujifilm X-A2', 10924000, 1, 1, '2016-11-16', 'Nhỏ gọn với khả năng vượt trội, thỏa sức sáng tạo', '<UL><LI>Cảm biến 16.3MP APS-C CMOS</LI><LI>Quay phim Full HD 1080p 30 fps</LI><LI>Màn hình 3.0” LCD xoay 175°</LI><LI>Chụp macro ở khoảng cách 15cm</LI><LI>AF nhận diện mắt; AF chụp Macro Tự động và AF đa điểm</LI><LI>Dung lượng pin cực lớn chụp tới 410 bức ảnh</LI><LI>Hệ thống chống rung ảnh 3 đến 3.5 điểm dừng</LI><LI>ISO 25600</LI></UL>', 'Thái Lan', 1, 1),
(2, 'Fujifilm X-T10', 22390000, 0, 4, '2016-11-01', ' thiết kế đẹp mắt,Độc đáo', '<UL><LI>Cảm biến APS-C X-Trans CMOS II 16.3 MP , Tích hợp Pop-Up Flash</LI><LI>Màn hình LCD lật 3.0 inch 920.000 điểm </LI><LI>Quay phim Full HD 1080p tại 60 fps</LI><LI>Chế độ lấy nét tự động thông minh 77 khu vực</LI><LI>Chụp 8 hình/giây and ISO 51200, hỗ trợ kết nối  Wi-Fi </LI></UL>', 'Nhật Bản', 1, 1),
(3, 'Sony Alpha ILCE-6000L', 13500000, 1, 5, '2015-11-15', 'Thiết kế đọc đáo, hình ảnh chất lương cao', '<UL><LI>Kích thước màn hình 3 inch,  Độ phân giải camera 24,3 MP,  Loại màn hình TFT LCD</LI><LI>Kích thước sản phẩm 14.5x13x15.5, Độ nhạy sáng ISO Auto – 25600</LI><LI>Cổng kết nối Mass-storage, MTP, PC remote, HDMI micro (Type-D)</LI><LI>Bộ xử lý BIONZ cho tốc độ xử lý nhanh</LI></UL>', 'Nhật Bản', 1, 2),
(4, 'mirrorless Canon EOS M3', 10390000, 0, 25, '2015-10-15', 'Cảm biến và bộ xử lý hình ảnh cao cấp', '<UL><LI>Cảm biến CMOS APS-C 24.2MP</LI><LI>Cảm biến hình ảnh DIGIC 6</LI><LI>Màn hình cảm ứng LCD 3.0 inch 1.040k-Dot</LI><LI>Quay phim Full HD 1080p tại 24/24/30fps</LI><LI>Tích hợp kết nối NFC và Wifi</LI><LI>Công nghệ lấy nét Hybrid CMOS AF với 49 điểm</LI><LI>ISO 100-12800; mở rộng 25600</LI></UL>', 'Nhật Bản', 1, 3),
(5, 'Nikon 1 J2', 6900000, 0, 14, '2016-07-15', 'Nhỏ gọn đày nữ tính', '<UL><LI>Kích thước màn hình 3 inch, Độ phân giải camera 10 MP</LI><LI>Kích thước sản phẩm (D x R x C cm) 15x8x16, Zoom quang 1.0</LI><LI>[ Chế độ Chọn Ảnh Thông minh ] Bắt đầu chụp trước khi nhấn cửa trập</LI><LI>Quay phim Full HD 1080p tại 24/24/30fps</LI><LI>[ Full HD ] Tận hưởng khả năng quay phim Full HD</LI><LI>Đèn nháy gắn sẵn </LI><LI>Bật/tắt với thấu kính có thể thu lại</LI></UL>', 'Nhật Bản', 1, 4),
(6, 'Olympus PEN mini E-PM2', 12029000, 0, 13, '2017-11-16', 'Hình ảnh chất lượng cao, Lấy nét chỉ bằng động tác chạm ngón tay', '<UL><LI>Độ phân giải camera  16.1MP</LI><LI>Cảm biến 4/3 Live MOS Sensor</LI><LI>Lens M.ZUIKO 14-42mm, Độ nhạy sáng ISO 200 – 25600</LI><LI>Màn hình 3” LCD, Mẫu mã E-PM2-1442-2RK(G)RED/SLV</LI><LI>Trọng lượng 0.325 kg</LI></UL>', 'Việt Nam', 1, 5),
(7, 'Olympus PEN E-PM2', 10359000, 0, 14, '2016-10-14', 'Quay phim HD, giảm rung và chống bám bẩn', '<UL><LI>Màn hình cảm ứng 3.0 inch, Độ phân giải camera 16 MP</LI><LI>Lấy nét nhanh chóng từ màn hình, Chất lượng hình ảnh 4608 x 3456</LI><LI>Kích thước sản phẩm  0.325 x 24.5 x 10  (D x R x C cm)</LI><LI>Độ nhạy sáng ISO 200 – 26500</LI><LI>Trọng lượng 0.325 kg</LI></UL>', 'Trung quốc', 1, 5),
(8, 'Nikon J3', 7959000, 0, 34, '2013-11-15', 'Thiết kế cao cấp, Kiểu dáng nhỏ gọn và nhiều màu sắc đa dạng', '<UL><LI>Cảm biến 1\" CX-CMOS độ phân giải 14.2 Megapixels</LI><LI>Tốc độ chụp liên tiếp 10 hình/giây khi lấy nét tự động</LI><LI>Bộ xử lý ảnh EXPEED 3 - ISO 160-6400</LI><LI>Quay phim Full-HD 1080p với âm thanh Stereo</LI><LI>Màn hình siêu nét 3” độ phân giải 921K điểm ảnh</LI><LI>Sản phẩm mới 100%; Giá gồm VAT</LI></UL>', 'Trung quốc', 1, 4),
(9, 'Panasonic Lumix DMC-GH4 body  ', 42000000, 1, 23, '2015-08-14', 'đẹp , bền, có khả nang chống nước, chống bụi', '<UL><LI>Cảm biến Live-MOS 16-Mpix </LI><LI>Chụp liên tục 12 khung hình/giây khi lấy nét đơn (AF-S) </LI><LI>Hệ thống lấy nét tự động theo tương phản 49 điểm</LI><LI>Màn hình OLED sau lật xoay 3.0 inch 1.03 triệu điểm ảnh</LI><LI>Quay phim DCI 4K (4096 x 2160) 24p</LI><LI>Quay phim UHD 4K 3840 x 2160 30/24p</LI><LI>Quay phim Full HD lên tới 60p</LI><LI>Đầu ra HDMI 4:2:2 8-Bit hoặc 10-Bit </LI></UL>', 'Trung quốc', 1, 6),
(10, 'Canon EOS 700D', 9850000, 0, 20, '2013-06-16', 'Thiết kế mới , tinh sảo', '<UL><LI>Kích thước màn hình 3inch, Có Ống kính đi kèm(18-55 STM) </LI><LI>Độ phân giải camera   18 Megapixels,Loại pin: Li-ion</LI><LI>SensorType: CMOS, Kích thước sản phẩm 13.2 x 9.9x 7.9 (D x R x C cm)</LI><LI>LensModel: Lens EF-S 18-55mm IS STM</LI><LI>LensKit: Có,CameraAddAcc: Thẻ nhớ 8GB</LI></UL>', 'Đài Loan', 2, 3),
(11, 'Canon EOS 70D', 19200000, 0, 33, '2012-11-15', 'Giá rẻ với nhiều tính năng hấp dẫn', '<UL><LI>Cảm biến CMOS 20.2 MP kích thước APS-C</LI><LI>Đóng nhãn hiệu: Torrini</LI><LI>Bộ xử lý hình ảnh: DIGIC 5+</LI><LI>Màn hình LCD ClearView II 3inch</LI><LI>ISO 100-12.800 (mở rộng 25.600), quay phim tối đa 6.400</LI><LI>Hỗ trợ kết nối Wi-Fi</LI><LI>Hệ thống lấy nét Dual pixel AF 19 điểm</LI><LI>Tốc độ chụp 7 fps</LI><LI>Quay phim Full HD 1920 x 1080 pixel</LI></UL>\r\n<UL><LI>Cảm biến CMOS 20.2 MP kích thước APS-C</LI><LI>Đóng nhãn hiệu: Torrini</LI><LI>Bộ xử lý hình ảnh: DIGIC 5+</LI><LI>Màn hình LCD ClearView II 3inch</LI><LI>ISO 100-12.800 (mở rộng 25.600), quay phim tối đa 6.400</LI><LI>Hỗ trợ kết nối Wi-Fi</LI><LI>Hệ thống lấy nét Dual pixel AF 19 điểm</LI><LI>Tốc độ chụp 7 fps</LI><LI>Quay phim Full HD 1920 x 1080 pixel</LI></UL>', 'Nhật Bản', 2, 0),
(12, 'Sony SLT-A57K', 15990000, 0, 12, '2014-05-08', 'Thiết kế mạnh mẽ, cá tính', '<UL><LI>Loại ống kính: 18 - 55mm f3.5 - 5.6 , Độ phân giải 16.1 Mega Pixels</LI><LI>Độ lớn màn hình LCD (inch), Màn hình xoay lật 3.0\" Clear Photo LCD</LI><LI>Bộ cảm biến hình ảnh: APS-C HD CMOS, Độ nhạy sáng: ISO 16000</LI><LI>Tốc độ màn trập 1/4000 - 30s, digital Zoom Zoom kỹ thuật số rõ nét với Clear Image Zoom</LI><LI>Loại pin sử dụng: Pin Stamina có thời lượng sử dụng cao, quay phim: Chuẩn Full HD</LI><LI>Bộ nhớ trong: (Mb) Sử dụng thẻ MS và SD</LI><LI>Chụp quét toàn cảnh với 3D SWEEP PANORAMA</LI><LI>Đa dạng màu sắc với chức năng Picture Effect</LI></UL>', 'Nhật Bản', 2, 0),
(13, 'Sony A77 Mark II', 24289000, 0, 23, '2017-11-01', 'Kính ngắm điện tử độ phân giải cao XGA OLED, Nhiều hiệu ứng hình ảnh sáng tạo', '<UL><LI>Cảm biến Exmor CMOS 24.3MP</LI><LI>Màn hình xoay 3 chiều 3.0” OLED Tru-Finder</LI><LI>Quay phim Full HD</LI><LI>Hệ thống lấy nét 79 điểm</LI><LI>Vi xử lý BIONZ tiên tiến</LI><LI>Công nghệ gương mờ Translucent Mirror lấy nét nhanh và chính xác</LI><LI>Kết nối Wifi, NFC tích hợp</LI></UL>', 'Nhật Bản', 2, 2),
(14, 'Nikon D7200', 24090000, 0, 12, '2017-11-03', 'chụp ảnh tốc độ cao kéo dài, sắc nét ngay cả trong điều kiện ánh sáng yếu', '<UL><LI>Cảm biến ảnh: CMOS 24.2 MP. DX format. kích thước APS-C</LI><LI>Bộ xử lý hình ảnh: EXPEED 4</LI><LI>Bộ chuyển tín hiệu A/D: 14-bit. 12-bit</LI><LI>Màn hình: LCD 3.2\" độ phân giải 1.228.800 điểm ảnh</LI><LI>ISO: 25.600. tối ưu 100 - 6.400. mở rộng 102.800 với ảnh đen trắng</LI><LI>Hệ thống lấy nét: 51 điểm. 15 điểm cross-type</LI><LI>Quay phim: 1.920 x 1.080 pixel</LI><LI>Chụp liên tiếp: 6 fps</LI></UL>', 'Thái Lan', 2, 4),
(15, 'Nikon D750', 36000000, 0, 23, '2014-05-06', 'Tính Năng nổi bật, hình ảnh sắt nét', '<UL><LI>Màn hình RGB 3.2-inch;,1.2 triệu điểm ảnh hỗ trợ lật xoay nghiêng</LI><LI>Độ phân giải camera 24.3 MP, Kích thước màn hình 3 inch</LI><LI>Kích thước sản phẩm 40x40x25 (D x R x C cm), Trọng lượng 0.9  (KG)</LI><LI>Loại pin/ác quy Removable Rechargeable Battery</LI></UL>', 'Thái Lan', 2, 4),
(16, 'KTS Fujifilm FinePix S9900W', 6800000, 0, 5, '2014-05-16', 'lý tưởng cho người dùng yêu thích chụp ảnh hoàng hôn', '<UL><LI>Ống kính siêu zoom 50x (24mm-1200mm)</LI><LI>Ống kính zoom quang FUJINON có khẩu độ F2.9 – F6.5 sẽ giảm tối đa hiện tượng </LI><LI>Ống kính có tiêu cự (24mm-1200mm) cho khả năng zoom lên đến 50x </LI><LI>Kính ngắm EVF và cảm biến BSI-CMOS 16.2MP</LI><LI>Quay phim Full HD 1080i/60fps</LI><LI>Kích thước sản phẩm 12.26 x 8.69 x 11.62 (D x R x C cm)</LI><LI>Chụp ảnh thông minh, chụp ảnh từ xa và chỉ sẻ tức thì</LI></UL>', 'Trung Quốc', 2, 1),
(17, 'Canon EOS 6D Wifi', 40490000, 0, 3, '2017-10-07', 'Vỏ thiết kế chống nước, bụi bặm', '<UL><LI>Cảm biến Full-Frame CMOS 20.2MP</LI><LI>Bộ xử lý ảnh DIGIC 5+</LI><LI>Màn hình LCD Clear View 3.0\" 1.04m-Dot</LI><LI>Quay phim Full HD 1080p 30fps</LI><LI>Tích hợp Wifi và GPS</LI><LI>Hỗ trợ lấy nét tự động 11 điểm</LI><LI>Chụp ảnh liên tục 4.5 fps</LI></UL>', 'Nhật Bản', 2, 3),
(18, 'Compact Fujifilm XF1 (Nâu)', 7900000, 0, 2, '2015-05-15', 'Thiết kế quyến rũ tinh tế mang phong cách cổ điển', '<UL><LI>Cảm biến EXR CMOS 2/3\" độ phân giải 12.0 Mps</LI><LI>Ống kính Fujinon 25-100mm độ mở lớn tới f1.8</LI><LI>Tốc độ chụp liên tục lên tới 10 hình/s, ISO tới 12.800</LI><LI>Hỗ trợ định dạng RAW với các chế độ chuyên nghiệp</LI><LI>Quay phim FullHD 1920*1080, chụp Panorama 360°</LI><LI>Hỗ trợ lấy nét tự động 11 điểm</LI></UL>', 'Trung Quốc', 3, 1),
(19, 'Olympus Stylus TG-4 Tough', 7288000, 0, 5, '2015-07-08', 'Nhỏ gọn, năng động', '<UL><LI>Cảm biến BSI CMOS 1/2.3\" 16 triệu điểm ảnh</LI><LI>Chống nước với độ sâu tới 15m (sẽ được gia tăng lên 45m với bộ giáp lặn PT-056) </LI><LI>Chống băng giá với nhiệt độ xuống tới -10 độ C</LI><LI>Chống lực đè nén lên tới 100kg</LI><LI>Chống sốc với độ cao 2.1m </LI><LI>Ống kính siêu nhanh f/2.0 với dải zoom rộng: 25-100mm (quy chuẩn 35mm) f/2.0-4.9</LI><LI>Màn hình lớn 3 inch với tấm nền bảo vệ chắc chắn</LI><LI>ISO 100-6400 và chụp ảnh liên tiếp 5 hình/giây </LI><LI>Hỗ trợ chụp ảnh RAW, quay phim Full HD</LI></UL>', 'Việt Nam', 3, 5),
(20, 'Olympus Stylus 1', 15948000, 0, 7, '2016-04-03', 'Thiết kế tinh sảo, chắc chắn', '<UL><LI>Cảm biến CMOS 1/1.7\" 12MP</LI><LI>Định dạng ảnh: JPEG, RAW</LI><LI>Định dạng video: MJPEG, MOV, MPEG-4 AVC/H.264</LI><LI>Định dạng âm thanh: Linear PCM (Stereo)</LI><LI>Tiêu cự: 6.0-64.3 mm (tương đương 28-300 mm trên máy full-frame) </LI><LI>Tốc độ màn trập 60 - 1/2000 seconds</LI></UL>', 'Nhật Bản', 3, 5),
(21, 'Canon EOS M10', 7290000, 0, 9, '2016-11-15', 'Nhỏ gon, thân thiện với người dùng', '<UL><LI>Độ phân giải 18 Megapixel</LI><LI>Tiêu cự 24-600mm</LI><LI>Hệ thống zoom zoom quang học 25x</LI><LI>Bộ xử lý ảnh DIGIC 6</LI><LI>Màn hình LCD cảm ứng điện dung 3.2 inch </LI><LI>Tốc độ ISO ISO 12012.800 auto</LI><LI>Nguồn điện Bộ pin NB-10L</LI><LI>Quay Phim Full HD 60p, MP4, chống rung</LI></UL>', 'Nhật Bản', 3, 3),
(22, 'Panasonic DMC-LX100', 19668000, 0, 11, '2017-04-28', 'bộ xử lý hình ảnh Venus Engine thế hệ mới, nhỏ gọn, trọng lượng nhẹ', '<UL><LI>Chụp ảnh rõ nét với cảm biến CMOS 12.8MP 1, zoom quang 3.1x</LI><LI>HĐộ nhạy sáng  ISO 200-25600</LI><LI>Quay phim Full HD</LI><LI>Màn hình LCD 3 inch sắc nét, Kích thước sản phẩm 12 x 7 x 6 (D x R x C cm)</LI><LI>Kết nối Wi-Fi</LI><LI>Nguồn điện Bộ pin NB-10L</LI><LI>Quay Phim Full HD 60p, MP4, chống rung</LI></UL>', 'Trugn Quốc', 3, 6),
(23, 'KTS Panasonic lDMC-LX7 Lumix', 9500000, 1, 12, '2015-10-10', 'Trang bị thêm nhiều tính năng hiện đại, Thiết kế nhỏ gọn, tiện lợi', '<UL><LI>Độ phân giải 10.1 MPXs</LI><LI>Góc chụp siêu rộng 24mm</LI><LI>Ống kính LEICA DC VARIO-SUMMICRON 3.8x độ mở F2.0</LI><LI>Bộ xử lý ảnh tiên tiến Venus Engine thế hệ IV</LI><LI>Độ nhạy sáng ISO lên tới 12.800, chụp Macro 1cm</LI><LI>Quay phim HD chất lượng cao âm thanh Stereo</LI><LI>Màn hình 3 inch, độ phân giải tới 460.000 điểm ảnh </LI></UL>', 'Nhật Bản', 3, 6),
(24, 'KTS Olympus Tough TG-2', 11000000, 0, 9, '2015-10-04', 'Thiết kế ấn tượng, Hình ảnh chat lượng cao, rõ nét', '<UL><LI>Độ phân giải camera 12(MP), Kích thước sản phẩm 13.5x 10.7x 14.9 (D x R x C cm)</LI><LI>Zoom quang 4x</LI><LI>Màn hình LCD 3.0 inch</LI><LI>Pin Lithium-Ion LI90B</LI><LI>Chụp dưới nước tối đa 15m</LI><LI>độ phân giải tới 460.000 điểm ảnh </LI></UL>', 'Nhật Bản', 3, 5),
(25, 'Fujifilm Instax Wide 300 (Đen)', 3350000, 0, 18, '2017-11-15', 'Chụp lấy ngay, tiện lợi dễ sử dụng', '<UL><LI>Kích thước ảnh: 99mm x 62mm, Đóng mở ống kính Fujino, 2 bộ phận, 2 cấu trúc, f = 95mm, F = 14</LI><LI>Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây</LI><LI>pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g</LI><LI>Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45</LI><LI>Trọng lượng 0.275 kg</LI><LI>gương phản chiếu xinh xắn ở mặt,độ nhạy sáng ISO Auto / 100 / 1600 / 200 / 3200 / 400 / 800</LI></UL>', 'Trung Quốc', 4, 1),
(26, 'Fujifilm Instax Mini 50s (Đen)', 3350000, 0, 5, '0000-00-00', 'Tinh tế và hoài cổ', '<UL><LI>Độ phân giải camera 1.5 MP</LI><LI>Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây</LI><LI>pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g</LI><LI>Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45.</LI></UL>', 'Trung Quốc', 4, 1),
(27, 'Fujifilm Instax mini 8', 1890000, 0, 7, '0000-00-00', 'Lấy hình ngay trong nhích nháy, Thiết kế trẻ trung và độc lạ', '<UL><LI>Kích thước ảnh 62x46mm</LI><LI>Model: Instax Mini 8 </LI><LI>Kích thước ảnh 62x46mm</LI><LI>Sử dụng pin AA</LI></UL>', 'Trung Quốc', 4, 1),
(28, 'Mini DV Recorder', 219000, 1, 4, '0000-00-00', 'Cực Nhỏ , với kích thước gọn đến không ngờ, tích hợp đủ chức năng', '<UL><LI>Độ phân giải : VGA 1280 * 960. 29fps</LI><LI>Hình ảnh độ phân giải: 5 MP</LI><LI>Độ phân giải webcam: 320 * 240</LI><LI>Ống kính góc: 60 độ</LI><LI>Chức năng phát hiện chuyển động video</LI><LI>Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh)</LI></UL>', 'Hồng Công', 5, 7),
(29, 'ASOCA002K', 1570000, 0, 3, '0000-00-00', 'Nhỏ , gọn, nhẹ', '<UL><LI>Chụp ảnh 16 mega pixels (16MP)</LI><LI>Màn hình hiển thị TFT LCD 2.7inch</LI><LI>Thẻ nhớ SD, MMC, hỗ trợ dung lượng lên đến 32GB</LI><LI>Chống rung, tự động nhận diện khuôn mặt, chụp nụ cười, chụp paranoma, pin sạc (BL-4C) qua cáp USB</LI><LI>Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh)</LI></UL>', 'Trung quốc', 5, 7),
(30, 'Fujifilm Instax Mini 70', 3660000, 0, 7, '0000-00-00', 'Thiết kế thời trang,sành điệu phù hợp với giới trẻ', '<UL><LI>Kích cỡ ảnh: 62 x 46 mm</LI><LI>Tích hợp đèn Flash</LI><LI>Pin: CR2/DL CR2 Lithium</LI></UL>', 'Trung Quốc', 5, 1),
(31, 'Canon PowerShot SX420 IS', 4950000, 0, 8, '0000-00-00', 'Gọn, phù hợp với các chuyến đi xa', '<UL><LI>Độ lớn màn hình LCD (inch): 3.0 inch</LI><LI>Megapixel (Số điểm ảnh hiệu dụng): 20 Megapixel</LI><LI>Độ phân giải ảnh lớn nhất: 5152 x 3864</LI><LI>Optical Zoom (Zoom quang): 42x</LI><LI>Digital Zoom (Zoom số): 4.0x</LI><LI>Tính năng: Wifi, Nhận dạng khuôn mặt, Voice Recording, Quay phim HD Ready</LI></UL>', 'Nhật Bản', 3, 3),
(32, 'KTS NiKonCoolpix L840', 6500000, 0, 5, '0000-00-00', 'Kiểu dáng mới lạ,đẹp mắt', '<UL><LI>DisplaySize: 3</LI><LI>OpticalZoom: 38</LI><LI>Độ phân giải ảnh 16 Megapixels</LI><LI>BatteryType: alkaline LR6/L40</LI></UL>', 'Trung Quốc', 3, 4);

-- --------------------------------------------------------

--
-- Table structure for table `taikhoan`
--

CREATE TABLE `taikhoan` (
  `MaTK` int(11) NOT NULL,
  `TenDN` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MatKhau` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TenHienThi` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `DiaChi` varchar(256) COLLATE utf8_unicode_ci DEFAULT NULL,
  `DienThoai` varchar(11) COLLATE utf8_unicode_ci DEFAULT NULL,
  `DOB` date NOT NULL,
  `Email` varchar(30) COLLATE utf8_unicode_ci DEFAULT NULL,
  `MaLoaiTK` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `taikhoan`
--

INSERT INTO `taikhoan` (`MaTK`, `TenDN`, `MatKhau`, `TenHienThi`, `DiaChi`, `DienThoai`, `DOB`, `Email`, `MaLoaiTK`) VALUES
(1, 'hauhero', '123456', ' trương Văn Hâu 1', 'gialai', '01689194021', '2017-11-24', 'truowngvanhau@gmail.com', 0),
(2, 'hauhero', '81dc9bdb52d04dc20036dbd8313ed055', 'hero hậu', 'gialai', '01689194021', '2017-11-30', 'truowngvanhau@gmail.com', 0),
(3, 'hauhero', 'f459c8d26c526358e86200e2c6fcfeb8', ' trương Văn Hâu2 ', 'gialai', '01689194021', '2017-11-25', 'truowngvanhau@gmail.com', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chitietdondathang`
--
ALTER TABLE `chitietdondathang`
  ADD PRIMARY KEY (`MaChiTietDonDatHang`);

--
-- Indexes for table `dondathang`
--
ALTER TABLE `dondathang`
  ADD PRIMARY KEY (`MaDonDatHang`);

--
-- Indexes for table `hangsx`
--
ALTER TABLE `hangsx`
  ADD PRIMARY KEY (`MaHangSX`);

--
-- Indexes for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  ADD PRIMARY KEY (`MaLoaiSP`);

--
-- Indexes for table `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MaSP`);

--
-- Indexes for table `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`MaTK`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `chitietdondathang`
--
ALTER TABLE `chitietdondathang`
  MODIFY `MaChiTietDonDatHang` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT for table `dondathang`
--
ALTER TABLE `dondathang`
  MODIFY `MaDonDatHang` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `hangsx`
--
ALTER TABLE `hangsx`
  MODIFY `MaHangSX` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  MODIFY `MaLoaiSP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MaSP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
--
-- AUTO_INCREMENT for table `taikhoan`
--
ALTER TABLE `taikhoan`
  MODIFY `MaTK` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
