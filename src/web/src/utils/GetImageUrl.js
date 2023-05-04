export const getImageAssetsSlider = (item) => {
    return new URL(`../assets/slider/slider${item}.jpg`,
        import.meta.url).href
}