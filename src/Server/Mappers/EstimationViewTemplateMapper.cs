//using Server.Enteties.EstimationView;
//using SharedLibrary.DTOs.EstimationView;

//namespace Server.Mappers;

//public static class EstimationViewTemplateMapper
//{
//    public static EstimationViewTemplate FromDto(EstimationViewTemplateDto dto)
//    {
//        if (dto == null)
//            return null;

//        var entity = new EstimationViewTemplate
//        {
//            Id = dto.Id,
//            Name = dto.Name,
//            NetSheetSectionTemplate = NetSheetSectionTemplateMapper.FromDto(dto.NetSheetSectionTemplate),
//            HeaderOrFooters = HeaderOrFooterMapper.FromDto(dto.TopLeftHeader, dto.TopRightHeader, dto.BottomLeftFooter, dto.BottomRightFooter),
//            DataSectionTemplates = DataSectionTemplateMapper.FromDto(dto.DataTemplateSections),
//        };

//        return entity;
//    }

//    public static EstimationViewTemplateDto ToDto(EstimationViewTemplate entity)
//    {
//        if (entity == null)
//            return null;

//        var dto = new EstimationViewTemplateDto
//        {
//            Id = entity.Id,
//            Name = entity.Name,
//            NetSheetSectionTemplate = NetSheetSectionTemplateMapper.ToDto(entity.NetSheetSectionTemplate),
//            TopLeftHeader = HeaderOrFooterMapper.ToDto(entity.HeaderOrFooters, HeaderOrFooterPosition.TopLeft),
//            TopRightHeader = HeaderOrFooterMapper.ToDto(entity.HeaderOrFooters, HeaderOrFooterPosition.TopRight),
//            BottomLeftFooter = HeaderOrFooterMapper.ToDto(entity.HeaderOrFooters, HeaderOrFooterPosition.BottomLeft),
//            BottomRightFooter = HeaderOrFooterMapper.ToDto(entity.HeaderOrFooters, HeaderOrFooterPosition.BottomRight),
//            DataTemplateSections = DataSectionTemplateMapper.ToDto(entity.DataSectionTemplates),
//        };

//        return dto;
//    }
//    public static class NetSheetSectionTemplateMapper
//    {
//        public static NetSheetSectionTemplate FromDto(NetSheetSectionTemplateDto dto)
//        {
//            if (dto == null)
//                return null;

//            var entity = new NetSheetSectionTemplate
//            {
//                Id = dto.Id,
//                Order = dto.Order,
//                Columns = SheetColumnMapper.FromDto(dto.Columns),
//            };

//            return entity;
//        }

//        public static NetSheetSectionTemplateDto ToDto(NetSheetSectionTemplate entity)
//        {
//            if (entity == null)
//                return null;

//            var dto = new NetSheetSectionTemplateDto
//            {
//                Id = entity.Id,
//                Order = entity.Order,
//                Columns = SheetColumnMapper.ToDto(entity.Columns),
//            };

//            return dto;
//        }
//    }

//    public static class HeaderOrFooterMapper
//    {
//        public static HeaderOrFooter FromDto(HeaderOrFooterDto dto)
//        {
//            if (dto == null)
//                return null;

//            var entity = new HeaderOrFooter
//            {
//                Id = dto.Id,
//                Value = dto.Value,
//                Position = dto.Position,
//            };

//            return entity;
//        }

//        public static HeaderOrFooterDto ToDto(HeaderOrFooter entity)
//        {
//            if (entity == null)
//                return null;

//            var dto = new HeaderOrFooterDto
//            {
//                Id = entity.Id,
//                Value = entity.Value,
//                Position = entity.Position,
//            };

//            return dto;
//        }
//    }

//    public static class DataSectionTemplateMapper
//    {
//        public static DataSectionTemplate FromDto(DataSectionTemplateDto dto)
//        {
//            if (dto == null)
//                return null;

//            var entity = new DataSectionTemplate
//            {
//                Id = dto.Id,
//                Order = dto.Order,
//                Columns = DataColumnMapper.FromDto(dto.Columns),
//                RowCount = dto.RowCount,
//                Cells = CellTemplateMapper.FromDto(dto.Cells),
//            };

//            return entity;
//        }

//        public static DataSectionTemplateDto ToDto(DataSectionTemplate entity)
//        {
//            if (entity == null)
//                return null;

//            var dto = new DataSectionTemplateDto
//            {
//                Id = entity.Id,
//                Order = entity.Order,
//                Columns = DataColumnMapper.ToDto(entity.Columns),
//                RowCount = entity.RowCount,
//                Cells = CellTemplateMapper.ToDto(entity.Cells),
//            };

//            return dto;
//        }
//    }

//    public static class DataColumnMapper
//    {
//        public static List<DataColumn> FromDto(List<ColumnDto> dtos)
//        {
//            if (dtos == null)
//                return null;

//            var entities = new List<DataColumn>();
//            foreach (var dto in dtos)
//            {
//                entities.Add(new DataColumn
//                {
//                    Id = dto.Id,
//                    Order = dto.Order,
//                    WidthPercent = dto.WidthPercent,
//                });
//            }

//            return entities;
//        }

//        public static List<ColumnDto> ToDto(List<DataColumn> entities)
//        {
//            if (entities == null)
//                return null;

//            var dtos = new List<ColumnDto>();
//            foreach (var entity in entities)
//            {
//                dtos.Add(new ColumnDto
//                {
//                    Id = entity.Id,
//                    Order = entity.Order,
//                    WidthPercent = entity.WidthPercent,
//                });
//            }

//            return dtos;
//        }
//    }

//    public static class CellTemplateMapper
//    {
//        public static List<CellTemplate> FromDto(List<CellTemplateDto> dtos)
//        {
//            if (dtos == null)
//                return null;

//            var entities = new List<CellTemplate>();
//            foreach (var dto in dtos)
//            {
//                entities.Add(new CellTemplate
//                {
//                    Id = dto.Id,
//                    Row = dto.Row,
//                    Column = dto.Column,
//                    Value = dto.Value,
//                    Format = CellFormatMapper.FromDto(dto.Format),
//                });
//            }

//            return entities;
//        }
//        public static List<CellTemplateDto> ToDto(List<CellTemplate> entities)
//        {
//            var dtos = new List<CellTemplateDto>();
//            foreach (var entity in entities)
//            {
//                dtos.Add(new CellTemplateDto
//                {
//                    Id = entity.Id,
//                    Row = entity.Row,
//                    Column = entity.Column,
//                    Value = entity.Value,
//                    Format = CellFormatMapper.ToDto(entity.Format),
//                });
//            }

//            return dtos;
//        }
//    }

//    public static class CellFormatMapper
//    {
//        public static CellFormat FromDto(CellFormatTemplateDto? dto)
//        {
//            var entity = new CellFormat
//            {
//                FontFamily = dto.FontFamily,
//                FontSize = dto.FontSize,
//                Bold = dto.Bold,
//                Italic = dto.Italic,
//                Underline = dto.Underline,
//                Align = dto.Align,
//                Justify = dto.Justify,
//                FormatType = dto.FormatType,
//                ThoasandsSeparator = dto.ThoasandsSeparator,
//                DecimalCount = dto.DecimalCount,
//                IncludeTimeOfDay = dto.IncludeTimeOfDay,
//                BorderLeft = dto.BorderLeft,
//                BorderTop = dto.BorderTop,
//                BorderRight = dto.BorderRight,
//                BorderBottom = dto.BorderBottom,
//                Style = dto.Style,
//            };

//            return entity;
//        }
//        public static CellFormatTemplateDto ToDto(CellFormat entity)
//        {
//            var dto = new CellFormatTemplateDto
//            {
//                FontFamily = entity.FontFamily,
//                FontSize = entity.FontSize,
//                Bold = entity.Bold,
//                Italic = entity.Italic,
//                Underline = entity.Underline,
//                Align = entity.Align,
//                Justify = entity.Justify,
//                FormatType = entity.FormatType,
//                ThoasandsSeparator = entity.ThoasandsSeparator,
//                DecimalCount = entity.DecimalCount,
//                IncludeTimeOfDay = entity.IncludeTimeOfDay,
//                BorderLeft = entity.BorderLeft,
//                BorderTop = entity.BorderTop,
//                BorderRight = entity.BorderRight,
//                BorderBottom = entity.BorderBottom,
//                Style = entity.Style,
//            };

//            return dto;
//        }
//    }
//}
