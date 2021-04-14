class linear_regression:

    def __init__(self):
        self.intercept = 0
        self.slope = 0
        

    def predict(self, data):
        try:
            iterator = iter(data)
            res = [ ]
            for x in iterator:
                res.append(self.predict(x))
            return res
        except TypeError:
            return data*self.slope + self.intercept;

    @classmethod
    def __calcSsr(c,i,s,x_arr,y_arr):
        sR = []

        for z in range(len(x_arr)):
            expected = i+s*x_arr[z]
            actual = y_arr[z]
            res = (expected-actual)**2
            sR.append(res)

        return sum(sR)

    def fit(self, x_arr, y_arr):
        i = 1
        s = 1

        c = 0
        dir = 1
        step = 1

        pSsr = cSsr = linear_regression.__calcSsr(i,s,x_arr,y_arr)

        while (c <= 10):
            i += dir*step
            pSsr = cSsr
            cSsr = linear_regression. __calcSsr(i,s,x_arr,y_arr)

            if (cSsr > pSsr):
                dir *= -1
                step /= 2
                c += 1
        
        c = 0
        dir = 1
        step = 1

        while (c <= 10):
            s += dir*step
            pSsr = cSsr
            cSsr = linear_regression.__calcSsr(i,s,x_arr,y_arr)

            if (cSsr > pSsr):
                dir *= -1
                step /= 2
                c += 1

        print("{0} {1}".format(i, s))
        self.intercept = i
        self.slope = s
            