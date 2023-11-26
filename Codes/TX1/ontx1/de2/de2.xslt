<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="ThuVien">
		<html>
			<body>
				<p>TRƯỜNG DHCNHN <b style="margin-left:100px" >DANH MỤC SÁCH</b> </p>
				<xsl:for-each select="LoaiSach">
					<table>
						<tr>
							<th style="padding:20px 100px">
								Mã loại: <xsl:value-of select="@MaLoai"/>
							</th>
							<th>
								Loại sách: <xsl:value-of select="TenLoai"/>
							</th>
						</tr>
					</table>
					<table border="1" cellpadding="20px" style="margin-left:40px">
						<tr>
							<th>Mã sách</th>
							<th>Tên sách</th>
							<th>Tác giả</th>
							<th>Số trang</th>
							<th>Giá</th>
						</tr>
						<xsl:for-each select="Sach">
							<tr>
								<td>
									<xsl:value-of select="@MaSach"/>
								</td>
								<xsl:if test="ThongTin/TenSach = 'Lộc Đình Ký'">
									<td style="background:red">
										<xsl:value-of select="ThongTin/TenSach"/>
									</td>
								</xsl:if>
								<xsl:if test="ThongTin/TenSach != 'Lộc Đình Ký'">
									<td>
										<xsl:value-of select="ThongTin/TenSach"/>
									</td>
								</xsl:if>
								<td>
									<xsl:value-of select="ThongTin/TacGia"/>
								</td>
								<xsl:if test="SoTrang &lt;=250">
									<td>
										<xsl:value-of select="SoTrang"/>
									</td>
								</xsl:if>
								<xsl:if test="SoTrang &gt;250">
									<td style="background:red">
										<xsl:value-of select="SoTrang"/>
									</td>
								</xsl:if>
								<td>
									<xsl:value-of select="SoTrang * 2500"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</xsl:for-each>
				
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
