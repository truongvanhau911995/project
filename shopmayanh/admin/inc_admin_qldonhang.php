 <?php
				
					  
					if(isset($_POST["txtDelete"])) 
					{
						$id= $_POST["txtDelete"];
						$sql = "delete  from dondathang where MaDonDatHang=$id";
						$rs = load($sql);
					}
					  $sql = "select * from dondathang ";
					  $rs = load($sql);
 ?>		
						<form id="frmDelete" name="frmDelete" action="" method="post">
                            <input type="hidden" id="txtDelete" name="txtDelete" />
                        </form>
						
						<table class="table table-bordered">
                                <thead>
								  <tr>
									<th>Mã đặt hàng</th>
									<th>Mã tài khoản</th>
									<th>Tổng thành tiền</th>
						
									<th>Ngày lập</th>
									<th>Thao tác</th>
									
								  </tr>
								</thead>
							<tbody>
									<?php
										while ($row = $rs->fetch_assoc()) {
									?>
											<tr>
												<th><?php echo $row["MaDonDatHang"]; ?></th>
												<th><?php echo $row["MaTK"]; ?></th>
												<th><?php echo $row["TongThanhTien"]; ?></th>
												<th><?php echo $row["NgayLap"]; ?></th>
											
												<th>
												<div class="col-sm-12">
													
													<div class="col-sm-4" style="float:left;">
														<button onclick="location.href='admin.php?act=updatedonhang&id=<?php echo $row['MaDonDatHang']?>'" type="submit" class="btn btn-success pull-right" name="btnUpdate">
															<i class="fa fa-check"></i> Cập Nhật
													</button>
													</div>
													<div class="col-sm-3">
													<button type="submit" class="btn btn-danger pull-right" name="btnDelete"
													        onclick="setDeleteId(<?php echo $row["MaDonDatHang"]; ?>)";>
														<i class="fa fa-mail-reply"></i> Xoá
													</button>
													</div>
												</div>
												</th>
											</tr>	
									<?php
								}
								?>
						</tbody>
					</table>
	<script type="text/javascript">	
		function setDeleteId(id) {
				document.getElementById("txtDelete").value=id;
				document.getElementById("frmDelete").submit();
			}	
</script>	
<?php
$js = <<<JS
<script src="assets/lightbox2/js/lightbox.min.js" type="text/javascript"></script>

    

JS;
?>