class LinearRegression:
    def __init__(self):
        self.intercept = 0
        self.slope = 0

    def predict(self, data):
        try:
            iterator = iter(data)
            res = []
            for x in iterator:
                res.append(self.predict(x))
            return res
        except TypeError:
            return data * self.slope + self.intercept

    def fit(self, x_arr, y_arr):
        self.intercept = 1
        self.slope = 1

        c = 0
        dir = 1
        step = 1

        cur_ssr = self.__calc_ssr(x_arr, y_arr)

        while c <= 10:
            self.intercept += dir * step
            prev_ssr = cur_ssr
            cur_ssr = self.__calc_ssr(x_arr, y_arr)

            if cur_ssr > prev_ssr:
                dir *= -1
                step /= 2
                c += 1

        c = 0
        dir = 1
        step = 1

        while c <= 10:
            self.slope += dir * step
            prev_ssr = cur_ssr
            cur_ssr = self.__calc_ssr(x_arr, y_arr)

            if cur_ssr > prev_ssr:
                dir *= -1
                step /= 2
                c += 1

    def __calc_ssr(self, x_arr, y_arr):
        sqr_res = []

        for z in range(len(x_arr)):
            expected = self.intercept + (self.slope * x_arr[z])
            actual = y_arr[z]
            res = (expected - actual) ** 2
            sqr_res.append(res)

        return sum(sqr_res)
