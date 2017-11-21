<!--

<div class="col-md-3">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Danh mục</h3>
        </div>

        <div class="list-group">
         
        </div>
    </div>
</div>

-->


<div class = "page-block page-block-top light-bg grid-container"></div> <!-dòng mau trang top->
<div class = "page-block page-block-bottom cream-bg grid-container">
    <div class = "sidebar-shadow push-25"></div>

    <div class = "sidebar grid-25 cream-gradient transition-all" id = "sidebar-mobile">

        <div class = "sidebar-box sidebar-top cream-gradient">
            <nav class = "submenu">
                <ul class = "expandable-menu">
                    <li class = "align-right back">
                        <a href = "#sidebar-mobile" class = "dark-color active-hover click-slide"><i class = "icon-chevron-right"></i></a>
                    </li>
                    <li class = "expanded">

                        <a href = "#" class = "dark-color active-hover selected" style="text-decoration:none">HÃNG SẢN XUẤT</a>
                        <ul>
                            <?php
                            require_once 'ketnoi.php';

                            $sql = "select * from hangsx";
                            $rs = load($sql);

                            while ($row = $rs->fetch_assoc()) {
                                $id = $row['MaHangSX'];
                                $name = $row['TenHangSX'];
                                ?>
                                <li>
                                    <a href="index.php?act=SanPhamTheoHang&id=<?php echo $id;?>" class="dark-color active-hover " style="text-decoration:none"><b class="middle-color">&rsaquo;</b> <?php echo $name; ?> </a>

                                </li>
                                <?php
                            }
                            ?>

                        </ul>

                        <!-- them ngay day -->
                        <a href="#" class="dark-color active-hover selected" style="text-decoration:none">LOẠI SẢN PHẨM</a>

                        <ul>
                            <?php
                            //  require_once 'ketnoi.php';

                            $sql1 = "select * from loaisanpham";
                            $rs1 = load($sql1);

                            while ($row1 = $rs1->fetch_assoc()) {
                                $id = $row1['MaLoaiSP'];
                                $name = $row1['TenLoaiSP'];
                                ?>
                                <li>
                                    <a href="index.php?act=SanPhamTheoLoai&id=<?php echo $id; ?>" class="dark-color active-hover" style="text-decoration:none"><b class="middle-color">&rsaquo;</b> <?php echo $name; ?></a>
                                </li>
                            <?php }
                            ?>

                        </ul>
                    </li>
                </ul>
            </nav>
        </div>
    </div> 

