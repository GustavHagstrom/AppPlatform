﻿namespace AppPlatform.Shared;
public static class CustomIcons
{
    public static string BidconIcon => @"<svg viewBox=""0 0 247.6 247.6"" xmlns=""http://www.w3.org/2000/svg"">
    <path d=""M 178.40625 5.0839844 L 75.957031 5.3261719 L 3.6855469 77.939453 L 3.9296875 180.38672 L 76.542969 252.6582 L 178.99023 252.41602 L 251.26172 179.80273 L 251.01953 77.353516 L 178.40625 5.0839844 z M 72.181641 76.228516 L 182.47656 76.228516 L 182.47656 180.11523 L 72.181641 180.11523 L 72.181641 76.228516 z ""/>
</svg>";

    public static string ReportsForBidcon => @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""275 140 1 190"">
            <path d=""M194.972 235c0-44.198 35.83-80.028 80.028-80.028 44.198 0 80.027 35.83 80.027 80.028 0 44.198-35.83 80.027-80.027 80.027-44.198 0-80.028-35.83-80.028-80.027zm8.369 0c0 39.24 31.81 71.05 71.049 71.05 16.548 0 31.775-5.658 43.851-15.144-9.197 5.121-19.789 8.038-31.062 8.038-35.316 0-63.945-28.629-63.945-63.944 0-35.316 28.63-63.944 63.945-63.944 11.273 0 21.865 2.917 31.062 8.038-12.076-9.486-27.303-15.143-43.851-15.143-39.24 0-71.05 31.81-71.05 71.049zm143.32 0c0-31.391-25.448-56.84-56.84-56.84a56.596 56.596 0 0 0-35.08 12.115c7.357-4.097 15.83-6.43 24.85-6.43 28.252 0 51.155 22.903 51.155 51.155 0 28.252-22.903 51.155-51.155 51.155-9.02 0-17.493-2.333-24.85-6.43a56.595 56.595 0 0 0 35.08 12.114c31.392 0 56.84-25.448 56.84-56.84zm-79.873-14.503v29.006h6.924v-12.272h10.772v-5.847h-10.772v-5.04h10.925v-5.847zm40.508 20.543c0-2.809-1.27-5.963-4.5-7.194 1.653-1.462 2.615-3.424 2.615-5.194 0-6-4.386-8.155-10.04-8.155H287.6v29.006h9.655c5.579 0 10.041-2.578 10.041-8.463zm-49.395-3.232c3.578-1.577 4.617-4.924 4.617-8.31 0-6.385-4.424-8.963-10.464-8.963h-9.348v28.968h6.924v-10.887h1.616l5.693 10.887h8.348l-7.386-11.695zm36.739-5.693h-.5v-6.155h.538c2.424 0 4.193.73 4.193 3.039 0 2.423-1.462 3.116-4.231 3.116zm-39.047-2.462c0 2.923-1.808 3.847-4.809 3.885h-1.154v-7.463h1.193c2.962 0 4.77.616 4.77 3.578zm44.779 10.925c0 3.078-2.04 3.462-5.194 3.462h-1.039v-6.655h.77c3.039 0 5.463.192 5.463 3.193zm64.674-3.803-.022.9-.03.899-.039.899-.047.899-.057.898-.065.898-.074.898-.083.896-.092.896-.101.895-.11.894-.12.893-.128.892-.137.89-.146.89-.155.887-.164.886-.173.884-.183.883-.191.88-.2.879-.21.876-.218.874-.227.872-.236.87-.245.866-.254.865-.262.862-.271.86-.28.856-.289.853-.296.85-.305.848-.314.844-.322.84-.33.838-.339.834-.346.831-.204.479-.358.821-.367.822-.375.818-.383.815-.392.81-.4.808-.407.802-.416.8-.424.794-.431.791-.44.787-.447.781-.456.778-.463.772-.471.768-.48.763-.486.758-.495.753-.502.749-.51.743-.517.737-.524.733-.532.727-.54.721-.546.716-.554.711-.56.705-.569.699-.575.693-.581.688-.589.682-.595.675-.601.67-.609.664-.614.657-.621.652-.627.645-.633.64-.369.366-.64.627-.648.624-.655.617-.661.611-.667.604-.673.598-.68.592-.684.585-.69.577-.697.572-.703.564-.707.556-.714.55-.72.543-.724.535-.73.528-.735.52-.74.514-.746.506-.751.497-.756.49-.761.483-.766.475-.77.467-.776.459-.78.45-.784.444-.788.435-.794.428-.797.42-.8.41-.806.403-.81.396-.812.387-.817.379-.82.37-.824.364-.827.354-.818.341-.834.339-.837.33-.84.323-.845.314-.847.306-.85.296-.853.29-.856.28-.86.27-.86.263-.866.254-.866.246-.87.236-.872.227-.873.219-.877.21-.878.2-.88.192-.883.183-.885.173-.885.165-.888.156-.889.147-.89.137-.892.128-.893.12-.894.11-.895.102-.896.092-.896.084-.898.074-.898.066-.898.057-.9.048-.9.038-.898.03-.9.023-.9.013-.9.004-.884-.004-.9-.013-.9-.021-.9-.03-.898-.039-.9-.047-.897-.057-.899-.065-.897-.074-.897-.084-.896-.092-.894-.1-.895-.11-.892-.12-.892-.128-.89-.137-.89-.146-.887-.155-.886-.165-.884-.173-.883-.183-.88-.191-.879-.2-.876-.21-.874-.218-.872-.227-.87-.236-.867-.245-.865-.254-.861-.262-.86-.27-.856-.28-.853-.29-.85-.296-.848-.305-.844-.314-.84-.322-.838-.33-.835-.338-.83-.347-.48-.204-.82-.357-.822-.367-.818-.376-.815-.383-.81-.392-.808-.4-.803-.407-.799-.416-.795-.423-.79-.432-.787-.44-.781-.447-.778-.455-.772-.464-.768-.47-.763-.48-.758-.487-.754-.494-.748-.503-.743-.509-.738-.517-.732-.525-.727-.532-.722-.54-.716-.546-.71-.554-.705-.56-.7-.568-.693-.575-.687-.582-.682-.589-.675-.595-.67-.6-.664-.61-.658-.614-.651-.62-.646-.627-.64-.634-.366-.368-.627-.64-.623-.649-.618-.655-.61-.66-.605-.668-.598-.673-.591-.678-.585-.686-.578-.69-.571-.697-.564-.702-.557-.708-.55-.713-.542-.72-.536-.724-.528-.73-.52-.735-.513-.741-.506-.746-.498-.75-.49-.756-.483-.761-.474-.766-.467-.77-.46-.776-.45-.78-.444-.784-.435-.789-.427-.793-.42-.797-.41-.801-.404-.805-.395-.81-.387-.813-.38-.816-.37-.82-.363-.825-.355-.827-.34-.817-.34-.834-.33-.838-.322-.84-.314-.844-.306-.847-.297-.85-.288-.853-.28-.857-.272-.859-.263-.861-.254-.865-.245-.867-.236-.87-.228-.871-.218-.874-.21-.876-.2-.879-.192-.88-.183-.883-.174-.884-.165-.886-.155-.887-.147-.89-.137-.89-.129-.891-.12-.893-.11-.895-.101-.894-.092-.896-.084-.897-.075-.898-.065-.898-.057-.898-.048-.899-.039-.9-.03-.899-.022-.9-.013-.9-.004-.899.004-.885.012-.9.022-.9.03-.899.039-.899.047-.899.057-.898.065-.898.074-.898.083-.896.092-.896.101-.895.11-.894.12-.893.127-.892.138-.89.146-.89.155-.887.164-.886.174-.884.182-.882.191-.88.2-.88.21-.876.218-.874.228-.872.236-.87.244-.867.254-.864.262-.862.272-.86.28-.856.288-.853.296-.85.306-.848.313-.844.322-.84.33-.838.339-.834.346-.831.204-.479.358-.821.367-.822.375-.818.384-.815.391-.81.4-.808.407-.803.416-.799.424-.795.431-.79.44-.786.447-.782.456-.777.463-.773.472-.768.479-.763.486-.758.495-.753.502-.749.51-.743.517-.737.524-.733.532-.727.54-.721.546-.716.554-.711.561-.705.568-.699.575-.693.581-.688.589-.681.595-.676.602-.67.608-.664.614-.657.621-.652.627-.646.633-.639.37-.367.639-.626.649-.624.654-.617.661-.611.667-.605.673-.598.68-.591.684-.585.69-.578.697-.57.703-.565.707-.557.714-.55.72-.542.724-.535.73-.528.735-.521.74-.513.746-.506.751-.498.756-.49.761-.482.766-.475.77-.467.776-.459.78-.451.784-.443.789-.436.793-.427.797-.42.801-.41.805-.404.81-.395.813-.387.816-.379.82-.37.824-.363.828-.355.817-.341.833-.339.838-.33.84-.323.845-.314.847-.305.85-.298.853-.288.856-.28.859-.272.862-.262.864-.254.867-.245.87-.237.871-.227.874-.219.877-.21.878-.2.88-.192.883-.183.884-.174.886-.164.888-.156.889-.146.89-.138.892-.128.893-.12.894-.11.895-.102.896-.092.896-.084.898-.074.898-.066.898-.057.9-.047.899-.04.899-.03.9-.022.9-.013.9-.004.885.004.9.013.899.021.9.03.898.039.9.047.898.057.898.065.897.074.897.083.896.092.895.101.894.11.893.12.891.128.89.137.89.146.887.155.886.165.884.173.883.182.88.192.879.2.877.21.874.218.872.227.869.236.867.245.865.253.862.263.859.27.856.28.854.289.85.297.847.305.844.314.841.322.837.33.835.338.83.347.479.204.821.357.822.367.818.376.815.383.811.391.807.4.803.408.8.415.794.424.79.431.787.44.782.448.777.455.772.464.768.47.763.48.759.487.753.494.748.502.743.51.738.517.732.525.727.532.722.539.716.547.71.553.705.561.7.568.693.575.687.582.682.588.676.595.67.602.663.608.658.615.651.62.646.628.64.633.366.368.627.64.623.649.618.655.61.66.605.668.598.673.592.679.584.684.578.691.571.697.564.702.557.708.55.713.543.72.535.724.528.73.52.735.514.74.505.747.498.75.49.757.483.76.475.766.467.77.459.776.45.78.444.784.435.789.428.793.419.797.411.801.403.806.395.809.387.813.38.817.37.82.363.824.354.827.342.817.338.834.33.837.323.841.314.844.306.847.297.85.289.853.28.857.271.859.263.861.253.865.246.867.236.869.228.872.218.874.21.876.2.879.193.88.182.883.174.884.164.886.156.887.147.89.137.89.129.891.12.893.11.894.101.895.093.896.083.897.074.897.066.899.057.898.048.899.039.9.03.899.022.9.013.9.004.899v.02l-.004.865zm-4.213-2.624-.013-.86-.02-.858-.028-.859-.038-.858-.045-.857-.054-.857-.062-.857-.071-.855-.08-.855-.087-.853-.097-.853-.105-.852-.113-.85-.123-.85-.13-.848-.14-.847-.148-.845-.157-.843-.165-.842-.173-.84-.183-.839-.19-.836-.2-.834-.208-.833-.217-.83-.224-.828-.234-.826-.241-.823-.25-.82-.259-.82-.266-.815-.275-.813-.283-.81-.291-.808-.3-.805-.307-.802-.315-.799-.323-.795-.325-.78-.338-.79-.346-.786-.354-.782-.361-.78-.369-.775-.376-.771-.384-.768-.392-.764-.4-.76-.406-.755-.415-.751-.422-.748-.43-.742-.437-.739-.444-.734-.452-.729-.46-.725-.466-.72-.474-.715-.481-.71-.489-.706-.495-.7-.503-.696-.51-.69-.516-.685-.524-.68-.53-.675-.538-.669-.544-.664-.55-.658-.558-.653-.564-.648-.57-.642-.576-.636-.584-.631-.588-.626-.595-.619-.605-.617-.344-.346-.61-.605-.617-.599-.622-.592-.627-.587-.633-.58-.639-.574-.644-.568-.65-.56-.654-.555-.661-.548-.666-.542-.672-.534-.677-.528-.682-.52-.687-.515-.692-.507-.697-.5-.703-.492-.707-.486-.712-.478-.718-.471-.721-.464-.727-.456-.731-.449-.736-.442-.74-.434-.745-.426-.749-.42-.753-.41-.757-.405-.762-.396-.765-.389-.77-.38-.773-.374-.776-.366-.781-.358-.784-.35-.792-.345-.448-.192-.793-.33-.796-.323-.798-.316-.802-.307-.805-.299-.807-.291-.81-.283-.813-.275-.816-.267-.819-.258-.82-.25-.824-.242-.825-.233-.828-.225-.83-.217-.833-.208-.834-.2-.837-.19-.838-.183-.84-.174-.842-.165-.843-.157-.846-.148-.846-.14-.848-.13-.85-.122-.85-.114-.852-.105-.853-.096-.853-.088-.855-.08-.856-.07-.856-.063-.857-.054-.858-.046-.858-.037-.859-.029-.859-.02-.86-.013-.845-.004-.859.004-.859.013-.859.02-.858.029-.858.037-.858.046-.857.053-.856.063-.856.07-.854.08-.854.088-.853.096-.852.105-.85.114-.85.122-.847.13-.847.14-.845.148-.844.157-.842.165-.84.174-.838.182-.836.19-.835.2-.832.208-.83.217-.828.225-.826.233-.823.242-.821.25-.819.258-.816.267-.813.275-.81.283-.808.29-.804.3-.802.307-.8.315-.795.323-.78.325-.789.339-.786.346-.783.353-.779.362-.775.368-.771.377-.768.384-.764.392-.76.4-.755.406-.752.414-.747.422-.743.43-.738.437-.734.445-.73.451-.724.46-.72.466-.715.474-.71.482-.706.488-.7.496-.696.502-.69.51-.685.517-.68.523-.675.531-.67.537-.663.544-.659.551-.653.557-.647.564-.642.57-.637.577-.63.583-.626.589-.62.595-.616.604-.347.344-.604.61-.599.617-.593.622-.586.627-.58.633-.574.639-.568.644-.561.65-.555.655-.548.66-.54.667-.535.671-.528.677-.521.682-.514.687-.507.692-.5.698-.492.702-.486.708-.478.712-.471.717-.464.722-.456.726-.45.732-.44.735-.435.74-.426.745-.42.75-.41.752-.405.758-.396.761-.389.766-.38.769-.374.773-.366.777-.358.78-.35.784-.346.792-.191.449-.33.792-.324.796-.315.799-.307.802-.3.804-.29.808-.284.81-.274.813-.267.816-.259.818-.25.82-.241.824-.234.826-.225.828-.216.83-.208.832-.2.835-.19.836-.183.838-.174.84-.165.842-.157.844-.148.845-.14.847-.13.848-.122.849-.114.85-.105.852-.097.853-.088.854-.08.855-.07.855-.062.857-.054.857-.046.858-.037.858-.029.858-.02.86-.013.859-.004.845.004.86.012.858.02.859.03.859.037.858.045.857.054.857.062.856.071.856.08.854.088.855.096.852.105.852.114.85.122.85.13.848.14.846.148.846.156.843.166.842.173.84.183.838.19.837.2.834.208.832.216.831.225.828.234.825.241.824.25.82.259.82.266.815.275.813.283.81.291.808.3.805.307.802.315.799.323.796.325.78.338.789.346.786.354.783.361.778.369.776.377.771.384.768.391.764.4.76.407.755.414.751.422.747.43.743.437.739.444.734.452.73.46.724.466.72.474.715.481.71.489.706.495.7.503.696.51.69.516.685.524.68.53.675.538.669.544.664.55.659.558.653.564.647.57.642.577.636.582.631.59.625.595.62.604.617.344.346.61.605.617.598.621.593.628.587.633.58.638.574.645.568.65.56.655.555.66.548.666.542.672.534.676.528.683.52.687.515.692.506.697.5.703.493.707.485.713.479.717.47.722.464.726.457.731.449.736.442.74.433.745.427.749.419.753.411.758.405.76.396.766.389.77.38.773.374.777.366.78.358.784.35.792.345.449.192.792.33.796.323.799.316.801.307.805.299.807.291.81.283.814.275.815.267.819.258.82.25.824.242.825.233.828.225.83.217.833.208.834.2.837.19.838.183.84.174.842.165.843.156.846.149.846.14.848.13.85.122.85.114.852.105.853.096.854.088.855.08.855.07.857.063.857.054.857.046.858.037.859.029.859.02.86.013.844.003.86-.003.859-.013.858-.02.86-.029.857-.037.857-.045.857-.054.857-.063.855-.07.855-.08.854-.088.852-.096.852-.105.85-.114.85-.122.848-.13.847-.14.845-.148.844-.156.841-.166.84-.173.839-.183.836-.191.835-.199.832-.208.83-.216.828-.225.826-.234.823-.242.821-.25.819-.258.815-.266.814-.275.81-.284.808-.29.804-.3.802-.307.799-.315.796-.323.78-.325.789-.339.786-.345.783-.354.779-.361.775-.37.772-.376.767-.384.764-.392.76-.399.755-.407.752-.414.747-.422.743-.43.738-.437.734-.444.73-.453.724-.459.72-.467.715-.473.71-.482.706-.488.7-.496.696-.502.69-.51.685-.517.68-.523.675-.531.67-.537.663-.544.659-.551.653-.557.647-.564.642-.57.637-.577.63-.583.626-.59.62-.594.616-.604.347-.344.604-.61.599-.617.592-.622.587-.627.58-.633.574-.639.568-.644.561-.65.555-.655.548-.66.54-.667.536-.67.528-.678.52-.682.514-.687.507-.692.5-.698.492-.702.486-.708.478-.712.472-.717.463-.722.456-.726.45-.732.44-.735.435-.74.427-.745.419-.75.411-.752.404-.758.396-.76.389-.767.381-.769.373-.773.366-.777.358-.78.35-.784.346-.792.191-.449.33-.792.324-.796.315-.799.307-.801.3-.805.29-.808.284-.81.274-.813.267-.815.259-.819.25-.82.242-.824.233-.826.225-.827.216-.83.208-.833.2-.834.19-.837.183-.838.174-.84.165-.842.157-.843.148-.846.14-.846.13-.848.122-.85.114-.85.105-.852.097-.853.088-.854.08-.855.07-.855.062-.857.055-.857.045-.857.037-.858.029-.86.02-.858.013-.86.004-.845v-.02z""/>
        </svg>";
    public static string BidconHub => @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""250 10 1 500"">
            <path d=""M 1326.7539 94.275391 L 603.34766 97.746094 L 94.275391 611.72852 L 97.748047 1335.1367 L 611.72852 1844.207 L 1335.1348 1840.7363 L 1844.207 1326.7539 L 1840.7344 603.34766 L 1326.7539 94.275391 z M 968.36328 322.1875 A 119.7301 118.72589 0 0 1 1088.0938 440.91211 A 119.7301 118.72589 0 0 1 986.21875 558.30469 L 986.21875 764.05664 L 986.5625 765.57031 A 195.60196 193.96138 0 0 1 1143.6914 865.80469 L 1340.5703 784.73828 A 119.7301 118.72589 0 0 1 1337.207 757.08594 A 119.7301 118.72589 0 0 1 1456.9375 638.35938 A 119.7301 118.72589 0 0 1 1576.668 757.08594 A 119.7301 118.72589 0 0 1 1456.9375 875.8125 A 119.7301 118.72589 0 0 1 1354.9648 819.27344 L 1354.0977 820.9707 L 1158.6895 900.59375 A 195.60196 193.96138 0 0 1 1167.8301 958.94531 A 195.60196 193.96138 0 0 1 1096.9863 1108.291 L 1236.5547 1281.2617 A 119.7301 118.72589 0 0 1 1298.4434 1264.0938 A 119.7301 118.72589 0 0 1 1418.1738 1382.8203 A 119.7301 118.72589 0 0 1 1298.4434 1501.5469 A 119.7301 118.72589 0 0 1 1178.7148 1382.8203 A 119.7301 118.72589 0 0 1 1206.8809 1306.4414 L 1065.9727 1129.0898 A 195.60196 193.96138 0 0 1 972.22852 1152.9062 A 195.60196 193.96138 0 0 1 870.98633 1124.8164 L 730.49023 1303.0371 A 119.7301 118.72589 0 0 1 761.49023 1382.7363 A 119.7301 118.72589 0 0 1 641.75977 1501.4609 A 119.7301 118.72589 0 0 1 522.0293 1382.7363 A 119.7301 118.72589 0 0 1 641.75977 1264.0098 A 119.7301 118.72589 0 0 1 698.76367 1278.334 L 840.55078 1102.2793 A 195.60196 193.96138 0 0 1 776.625 958.94531 A 195.60196 193.96138 0 0 1 784.2207 905.65234 L 583.33594 825.53125 A 119.7301 118.72589 0 0 1 487.06641 873.67969 A 119.7301 118.72589 0 0 1 367.33789 754.95312 A 119.7301 118.72589 0 0 1 487.06641 636.22852 A 119.7301 118.72589 0 0 1 606.79688 754.95312 A 119.7301 118.72589 0 0 1 601.30273 790.49414 L 796.71484 871.20898 L 796.71484 873.56055 A 195.60196 193.96138 0 0 1 949.9707 766.34961 L 949.9707 558.16016 A 119.7301 118.72589 0 0 1 848.63281 440.91211 A 119.7301 118.72589 0 0 1 968.36328 322.1875 z "" transform=""scale(0.26458)""/>
        </svg>";
}