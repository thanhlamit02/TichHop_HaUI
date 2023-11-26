<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="congty">
		<html>
			<head>
				<title>Bảng Lương</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div width="80%">
					<h2 align="center">Bảng lương tháng 11-2023</h2>
					<p>Mã đơn vị: <xsl:value-of select="@madv"/></p>
					<p>
						Tên đơn vị: <xsl:value-of select="donvi/tendv"/>
					</p>
					<p>
						Điện thoại: <xsl:value-of select="donvi/dienthoai"/>
					</p>
				</div>
				
				<div align="center" width="80%">
					<div class="title">DANH SÁCH NHÂN VIÊN</div>
					<table width="70%" border="1">
						<tr>
							<th>SỐ TT</th>
							<th>MÃ NV</th>
							<th>HỌ TÊN</th>
							<th>NGÀY SINH</th>
							<th>HS LƯƠNG</th>
							<th>LƯƠNG</th>
						</tr>
						<xsl:for-each select="donvi/nhanvien">
							<xsl:if test="hsluong &gt;= 3">
								<tr>
									<td class="so">
										<xsl:value-of select="position()"/>
									</td>
									<td class="chuoi">
										<xsl:value-of select="manv"/>
									</td>
									<td class="chuoi">
										<xsl:value-of select="hoten"/>
									</td>
									<td class="so">
										<xsl:value-of select="ngaysinh"/>
									</td>
									<td class="so">
										<xsl:value-of select="hsluong"/>
									</td>
									<td class="so">
										<xsl:value-of select="hsluong * 100000"/>
									</td>
								</tr>
							</xsl:if>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
