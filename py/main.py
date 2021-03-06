import numpy as np
from sklearn import datasets, linear_model
from linearregression import LinearRegression

# Load the diabetes dataset
diabetes_X, diabetes_y = datasets.load_diabetes(return_X_y=True)
diabetes_X = diabetes_X[:, np.newaxis, 2]

regr = linear_model.LinearRegression()  # sklearn impl
# regr = LinearRegression()  #  manual impl

regr.fit(diabetes_X, diabetes_y)

pred = regr.predict([[0.015]])

print("Prediction for 0.015: {0}".format(pred[0]))
