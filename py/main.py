import numpy as np
from sklearn import datasets, linear_model
from linear_regression import linear_regression

# Load the diabetes dataset
diabetes_X, diabetes_y = datasets.load_diabetes(return_X_y=True)
diabetes_X = diabetes_X[:, np.newaxis, 2]

regr = linear_model.LinearRegression()
# regr = linear_regression()

regr.fit(diabetes_X, diabetes_y)

pred = regr.predict([[0.015]])

print("Prediction for 0.015: {0}".format(pred[0]))