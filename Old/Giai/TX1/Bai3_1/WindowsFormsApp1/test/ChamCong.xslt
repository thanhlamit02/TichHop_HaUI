<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="ChamCong">
		<html>
			<head>
				<title>Bảng chấm công</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div width="100%" align="center">
					<h2>Bảng chấm công</h2>
					<table class="bang" width="60%" align="center" border="1">
						<tr>
							<th>STT</th>
							<th>Mã NV</th>
							<th>Ca làm việc</th>
							<th>Giờ vào</th>
							<th>Giờ ra</th>
							<th>Làm đêm</th>
						</tr>
						<xsl:for-each select="NgayLamViec">
							<tr >
								<td class="not" colspan="6">
									Ngày làm việc:
									<xsl:value-of select="@Ngay"/>
								</td>
							</tr>
							<xsl:for-each select="NhanVien">
								<tr>
									<td>
										<xsl:value-of select="position()"/>
									</td>
									<td>
										<xsl:value-of select="@MaNV"/>
									</td>
									<td>
										<xsl:value-of select="CaLamViec"/>
									</td>
									<td>
										<xsl:value-of select="GioVao"/>
									</td>
									<td>
										<xsl:value-of select="GioRa"/>
									</td>
									<td>
										<xsl:choose>
											<xsl:when test="CaLamViec = 'C3'">
												x
											</xsl:when>
											<xsl:otherwise>
												
											</xsl:otherwise>
										</xsl:choose>
									</td>
								</tr>
							</xsl:for-each>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
