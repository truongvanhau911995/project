<?php 
    include_once '../connect.php';
    session_start();
    if (isset($_POST["txtXProId"])) {
        $id = $_POST["txtXProId"];
        foreach ($_SESSION["cart"] as $key=>$value){  
            if ($key == $id) {
                unset($_SESSION["cart"][$key]);// xóa mảng
            }
        }
    }
    
    // XỬ LÝ UPDATE
    if (isset($_POST["txtUProId"])) {
        $id = $_POST["txtUProId"];// ID
        $sl = $_POST["txtUQ"];// SỐ LƯƠNG CẦN UPDATE 
        if($sl > 0)
        {
             foreach ($_SESSION["cart"] as $key=>$value){ 
                if ($key == $id) {
                    $_SESSION["cart"][$id] = $sl;
                }
            }
        }
        else
        {
            if($sl == 0)// NẾU CẬP NHẬT SỐ LƯỢNG BĂNG 0 THÌ XÓA LUÔN
            {
                 //$database->remove_cart_item($id);
                 foreach ($_SESSION["cart"] as $key=>$value){
                     if ($key == $id) {
                         unset($_SESSION["cart"][$key]);// xóa mảng
                     }
                 }
            }
        }
    }
   
    
    
    // XỬ LÝ THANH TOÁN
    
    if (isset($_POST["btnCheckout"])) {//KHI NÀO NHẤN VÀO NÚT THANH TOÁN THÌ MỚI THỰC HIỆN
         $total = $_SESSION['tongtien'];
         $userid = $_SESSION["MaTaiKhoan"];
         $order_date = date('Y-m-d H:i:s', time());
         $MaDonDatHang = time();// MÃ ĐƠN HÀNG
         $sql = "insert into dondathang(MaDonDatHang,NgayLap,TongThanhTien, MaTaiKhoan,MaTinhTrang ) values($MaDonDatHang,'$order_date',$total, $userid,1)";
         $order_id = $database ->query($sql);
         foreach ($_SESSION['cart'] as $key => $value){//THỰC HIỆN THÊM VÀO CHI TIẾT
             $quantity = $value;// số luong
             $id = $key;
            $sql = "select * from sanpham where MaSanPham=$id";
            $rs = $database ->query($sql);
            $row = mysqli_fetch_assoc($rs);
            $price = $row["GiaSanPham"];
            $sql = "insert into chitietdondathang(SoLuong, GiaBan,MaDonDatHang, MaSanPham) values($quantity,$price, $MaDonDatHang, $id)";
            $database->query($sql);
        }
        unset($_SESSION['cart']);
    }
?>

<div id="quanlygiohang">
	<h1>Quản lý giỏ hàng</h1>
	 <form action="" method="post" name="f"><!-- tạo các biến tạm ẩn -->
        <input type="text" name="txtXProId" />
        <input type="text" name="txtUProId" />
        <input type="text" name="txtUQ" />
    </form>
    <table>
    	<tr>
        	<th width="20">STT</th>
            <th>Tên sản phẩm</th>
            <th width="60">Hình</th>
            <th width="50">Giá</th>
            <th width="50">Số lượng</th>
            <th width="80">Thao Tác</th>
        </tr>
        
        <?php 
        if (isset($_SESSION['cart'])){
            $tongtien = 0;
            $i= 1;
           foreach ($_SESSION['cart'] as $key => $value){
                $query = "SELECT * FROM sanpham WHERE MaSanPham = ".$key;
                $result =$database->query($query);
                $row = mysqli_fetch_array($result);
                echo '<form name="frmGioHang" action="" method="post">
                    	<tr>
                            <td>'.$i++.'</td>
                            <td>
                            	'.$row['TenSanPham'].'   			                
                           </td>
                            <td align="center">
                                <img src="images/'.$row['HinhURL'].'" width="50">
                            </td>
                            <td>
                            '.$row['GiaSanPham'].' VNĐ</td>
                            <td>
                                <input type="text" id="txtSL_'.$row['MaSanPham'].'" value="'.$value.'" width="45" size="5" />
                            </td>
                            <td>
                            	<a href="javascript:;" role="button" onclick="setUProId('.$row['MaSanPham'].');">Edit</a> |
        	                	<a href="javascript:;" role="button" onclick="setXProId('.$row['MaSanPham'].');">Delete</a> 
                            </td>
                        </tr>
                    </form>';
               $tongtien = $tongtien + ($row['GiaSanPham'] * $value);
               $_SESSION['tongtien'] = $tongtien;
            
            }
         
        }     
        ?> 	       
    </table>
    <div class="pprice">
    	Tổng thành tiền: <?php echo $tongtien;?> đ
    </div>
    <form action="" method="post"  style="margin-top:10px;">
        <button type="submit" id="btnCheckout" name="btnCheckout" >
        	<img src="img/dathang.png" width="100">
        </button>
    </form>
   
</div>	
<script type="text/javascript">
    function setXProId(id) {
       f.txtXProId.value = id;
       f.submit();
    }
    
    function setUProId(id) {
        var idQ = "txtSL_" + id;
        var txtQ = document.getElementById(idQ);
        var q1 = txtQ.value;
        f.txtUProId.value = id;
        f.txtUQ.value = q1;  
        f.submit();
    }
</script>

