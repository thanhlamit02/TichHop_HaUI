<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<style>
			table{
			border-collapse: collapse;
			}
			th{
			padding-right: 40px
			}
		</style>
		<html>
			<body>
				<table>
					<tr>
						<th>TRƯỜNG ĐHCNHN</th>
						<th>DANH MỤC SÁCH</th>
					</tr>
				</table>
				<xsl:apply-templates select="ThuVien/LoaiSach"/>
			</body>
		</html>
    </xsl:template>

	<xsl:template match="LoaiSach">
		<table>
			<tr>
				<th>
					Mã loại: <xsl:value-of select="@MaLoai"/>
				</th>
				<th>
					Loại sách: <xsl:value-of select="TenLoai"/>
				</th>
			</tr>
		</table>

		<table border="1" cellpadding="20px">
			<tr style="background: yellow">
				<th>Mã Sách</th>
				<th>Tên Sách</th>
				<th>Tác Giả</th>
				<th>Số Trang</th>
				<th>Giá</th>
			</tr>
			<xsl:apply-templates select="Sach"/>
		</table>
		<br></br>
	</xsl:template>

	<xsl:template match="Sach">
		<tr>
			<td>
				<xsl:value-of select="@MaSach"/>
			</td>
			<td>
				<xsl:value-of select="Thongtin/TenSach"/>
			</td>
			<td>
				<xsl:value-of select="Thongtin/TacGia"/>
			</td>
			<!--<xsl:if test="SoTrang &gt;= 220">
				<td style="background: red">
					<xsl:value-of select="SoTrang"/>
				</td>
			</xsl:if>
			<xsl:if test="SoTrang &lt; 220">
				<td>
					<xsl:value-of select="SoTrang"/>
				</td>
			</xsl:if>-->
			<xsl:choose>
				<xsl:when test="SoTrang &gt;= 220">
					<td style="background: red">
						<xsl:value-of select="SoTrang"/>
					</td>
				</xsl:when>
				<xsl:when test="SoTrang &lt; 220">
					<td>
						<xsl:value-of select="SoTrang"/>
					</td>
				</xsl:when>
			</xsl:choose>
			<td>
				<xsl:value-of select="SoTrang * 2500"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
