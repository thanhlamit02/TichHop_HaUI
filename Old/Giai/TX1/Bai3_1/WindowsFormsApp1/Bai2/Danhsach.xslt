<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DS">
		<html>
			<head>
				<title>Bảng lương tháng</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div width="100%">
					<h1 align="center">BẢNG LƯƠNG THÁNG</h1>
				</div>
				<div width="80%" class="vien">
					<p >Tên công ty: <span class="tenct"><xsl:value-of select="congty/@TenCT"/></span></p>
					<p>
						Tên đơn vị: <xsl:value-of select="congty/donvi/tendv"/>
					</p>

					<table class="bang" border="1" width="80%" align="center">
						<tr>
							<th>STT</th>
							<th>Họ tên</th>
							<th>Ngày sinh</th>
							<th>Ngày công</th>
							<th>Lương</th>
						</tr>
						<xsl:for-each select="congty/donvi/nhanvien">
							<tr class="text">
								<td>
									<xsl:value-of select="position()"/>
								</td>
								<td>
									<xsl:value-of select="hoten"/>
								</td>
								<td>
									<xsl:value-of select="ngaysinh"/>
								</td>
								<td>
									<xsl:value-of select="ngaycong"/>
								</td>
								<td>
									<xsl:choose>
										<xsl:when test="ngaycong &lt;= 20">
											<xsl:value-of select="ngaycong * 150000"/>
										</xsl:when>
										<xsl:when test="ngaycong &lt;= 25">
											<xsl:value-of select="20 * 150000 + (ngaycong - 20) * 200000"/>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="20 * 150000 + 5 * 200000 + (ngaycong - 25) * 250000"/>
										</xsl:otherwise>
									</xsl:choose>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
