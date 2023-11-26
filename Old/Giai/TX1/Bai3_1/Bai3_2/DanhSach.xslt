<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DS/congty">
		<html>
			<head>
				<title>Bảng lương tháng</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div>
					<h2 align="center">BẢNG LƯƠNG THÁNG</h2>
					<span>
						Tên công ty: <span class="tenct"><xsl:value-of select="@TenCT"/></span> 
					</span>
					<p>
						Tên phòng: <xsl:value-of select="donvi/tendv"/>
					</p>
				</div>
				<table class="table" border="1" width="65%">
					<tr>
						<th>STT</th>
						<th>Họ tên</th>
						<th>Ngày sinh</th>
						<th>Ngày công</th>
						<th>Lương</th>
					</tr>
					<xsl:for-each select="donvi/nhanvien">
						<xsl:sort select="ngaycong" order="ascending"/>
						<tr>
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
										<xsl:value-of select="20 * 150000 + ( ngaycong - 20 ) * 200000"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="20 * 150000 + 5 * 200000 +( ngaycong - 25 ) * 250000"/>
									</xsl:otherwise>
								</xsl:choose>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
