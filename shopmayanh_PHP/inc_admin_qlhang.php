<?php
if (isset($_POST["txtDelete"])) {
    $id = $_POST["txtDelete"];
    $sql = "delete  from categories where CatID=$id";
    $rs = load($sql);
}
$sql = "select * from categories ";
$rs = load($sql);
?>		
<form id="frmDelete" name="frmDelete" action="" method="post">
    <input type="hidden" id="txtDelete" name="txtDelete" />
</form>
<div class="col-sm-1" style="float:left;padding-bottom: 10px;">
    <button onclick="location.href = 'index.php?act=themhang'" type="submit" class="btn btn-success pull-right" name="btnUpdate">
        <i class="fa fa-plus"></i> Thêm
    </button>
</div>
<table class="table table-bordered">
    <thead>
        <tr>
            <th>Tên hãng</th>
            <th>Thao tác</th>

        </tr>
    </thead>
    <tbody>
<?php
while ($row = $rs->fetch_assoc()) {
    ?>
            <tr>
                <th><?php echo $row["CatName"]; ?></th>
                <th>
        <div class="col-sm-12">

            <div class="col-sm-4" style="float:left;">
                <button onclick="location.href = 'admin.php?act=updatehang&id=<?php echo $row['CatID'] ?>'" type="submit" class="btn btn-success pull-right" name="btnUpdate">
                    <i class="fa fa-check"></i> Cập Nhật
                </button>
            </div>
            <div class="col-sm-3">
                <button type="submit" class="btn btn-danger pull-right" name="btnDelete"
                        onclick="setDeleteId(<?php echo $row["CatID"]; ?>)";>
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
        document.getElementById("txtDelete").value = id;
        document.getElementById("frmDelete").submit();
    }
</script>	
<?php
$js = <<<JS
<script src="assets/lightbox2/js/lightbox.min.js" type="text/javascript"></script>

    

JS;
?>