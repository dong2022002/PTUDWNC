export const formatPrice = (value) => {
  var formatter = new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",

    minimumFractionDigits: 0,
  });
  return formatter.format(value);
};
