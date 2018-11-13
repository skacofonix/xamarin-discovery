namespace Giphy.Api
{
    public class Images
    {
        public Fixed_Height fixed_height { get; set; }
        public Fixed_Height_Still fixed_height_still { get; set; }
        public Fixed_Height_Downsampled fixed_height_downsampled { get; set; }
        public Fixed_Width fixed_width { get; set; }
        public Fixed_Width_Still fixed_width_still { get; set; }
        public Fixed_Width_Downsampled fixed_width_downsampled { get; set; }
        public Fixed_Height_Small fixed_height_small { get; set; }
        public Fixed_Height_Small_Still fixed_height_small_still { get; set; }
        public Fixed_Width_Small fixed_width_small { get; set; }
        public Fixed_Width_Small_Still fixed_width_small_still { get; set; }
        public Downsized downsized { get; set; }
        public Downsized_Still downsized_still { get; set; }
        public Downsized_Large downsized_large { get; set; }
        public Original original { get; set; }
        public Original_Still original_still { get; set; }
    }
}