 <?php
				
					  
					if(isset($_POST["txtDelete"])) 
					{
						$id= $_POST["txtDelete"];
						$sql = "delete  from sanpham where MaSP=$id";
						$rs = load($sql);
					}
					  $sql = "select * from sanpham  order by GiaSP";
					  $rs = load($sql);
 ?>		
						<form id="frmDelete" name="frmDelete" action="" method="post">
                            <input type="hidden" id="txtDelete" name="txtDelete" />
                        </form>
						
						<table class="table table-bordered">
                                <thead>
								  <tr>
									<th>Tên sản phẩm</th>
                                                                        <th>Hinh</th>
									<th>Giá</th>
									<th>So luot xem</th>
									
									<th>Số lượng bán</th>

									<th>Ngay nhap</th>
								  </tr>
								</thead>
							<tbody>
									<?php
										while ($row = $rs->fetch_assoc()) {
									?>
											<tr>
												<th><?php echo $row["TenSP"]; ?></th>
												<th>
												 <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="..." style="width: 270px;height: 270px"></th>
												<th><?php echo number_format($row["GiaSP"]); ?></th>
											
												<th><?php echo $row["SoLuongBan"]; ?></th>
												<th><?php echo $row["NgayNhap"]; ?></th>
												<th>
												<div class="col-sm-12">
													
													<div class="col-sm-4" style="float:left;">
														<button onclick="location.href='admin.php?act=updatesanpham&id=<?php echo $row['MaSP']?>'" type="submit" class="btn btn-success pull-right" name="btnUpdate">
															<i class="fa fa-check"></i> Cập Nhật
													</button>
													</div>
													<div class="col-sm-3">
													<button type="submit" class="btn btn-danger pull-right" name="btnDelete"
													        onclick="setDeleteId(<?php echo $row["MaSP"]; ?>)";>
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