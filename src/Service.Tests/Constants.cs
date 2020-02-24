using System;
using System.IO;

namespace Service.Tests
{
    public static class Constants
    {
        public static string ImageBase64 => "/9j/4AAQSkZJRgABAQEAkACQAAD/4QAiRXhpZgAATU0AKgAAAAgAAQESAAMAAAABAAEAAAAAAAD//gA8Q1JFQVRPUjogZ2QtanBlZyB2MS4wICh1c2luZyBJSkcgSlBFRyB2NjIpLCBxdWFsaXR5ID0gOTAKAP/bAEMAAgEBAgEBAgICAgICAgIDBQMDAwMDBgQEAwUHBgcHBwYHBwgJCwkICAoIBwcKDQoKCwwMDAwHCQ4PDQwOCwwMDP/bAEMBAgICAwMDBgMDBgwIBwgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDP/AABEIADgAZAMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APyVuCtuh3HtX6R/8G9X7ZVj8EfiRqWgalcLb2+sSJJEzNgFgNp/pX5Za/4oaRcLXffsweLptP8AFEDCSSGRZP3bqcMD1618/WxU8NFYiK1jr/mRWw6rQ9m9Ln9g2h/HnR7zRluPtkO0ruzvFfLv7e//AAU18PfBfwfdW9nfR3OqzIVigicFif6V+W3gz9pjxw/hBLFfEF/5ITA+bJH414t8T7/VLjxM1zf3FxdG6O7zZWLMT3FefW40jODjhoWn59DCWU12rVZe75dTuF+KusfEb4m3viTU7iWa+1CcyElidgJ4Uew6V3Pi744PoOhRvebpITIkJKn5l3HAP4Hk8HjP1Hj3g6Y+QrbWAbODjqRjv+I/OuzvtW03xr4jsdF1RWt7zWWjutNuypdY7pNyzjqADmTds5Xy5Og5FfkOdYurDmxFWMpLq09V5/Ldn6z4b5LRx2Pjhak4xUbNRkrqaW8VqrO23z7DPDnhh9a1q4/tS6uPsIL3F1exLjym2btwUk4VgqgAKeSDx81c54q1RtQa4bTRJNYxxLMrhTtRTGHIYnuPmHPUjivdPAnhSCG3uLK4tYYZhYWs8iOGOz95MGiUHkKfl5OMbgNp5I479q3WG8FfCS1txHcfZLy8S0MgRliErg3TAE4HzBV+6OxGWAJPyOUcSVquYwwavPnairuyS0blazvp0ul+v7jx5wjlMsqq4+EVSlSXM3GK960XGMOlrycby1tbZ9Pn/Qvihd6fqpTewCn1r1zw58StSlsmwZVaFQ3LbSoJA/qPzz0rnPgb+yo3xf8Ahn4g8TyXFxZ3ELE6ZHswtwsWPMJ3Ebt7OqLtOQVY4Ir2e8+BpuoGkuJI5rnTmC3LW9uvzSBVRiMbThVGRuOOSAecD2M/z/KI4v6pe8oy5ZaPR+75a7206po/NOGeBc3xeBljZWhBw5oXa974rLfS9ou705ZJ36HLaR8Ub+7lZbiaViOAcmp7xtQ8VONqysmMDiuo8IfDLzJ43FjJubk5WvStD+H/ANmsGZrdY9vXIr0J0cLh486SufC4nEV6q5U2fLOufB66vNQZmU7unNFfR+qeB5Jrstjbx0oohxNKEVG+x4UspryfNZn4gW/h7UNS2stpctD3YIa9T+DuiPp+o27LbyKwYMCUPUV+plh+wTovm28Fpp0E0eNqt5YyCOoPFet/Cr/gmjo9gZJvsliqzcsGjDH8OOK+gr+JWFxEHFQ09T6qt4d4ulZuaPmH9nbwg/xC0uDyoysfCyNj7pPbFd98R/g5Z6T4303w/deH21K11S3Fxb34uFjELhthilU88thg6nBDEcFcn6+8OfsqaJ8KJI/stuoUtuOFxz+FeCftl6tqGn/HP+ztONjqGjjR4VlmG2Z9LuHeYNA0KfM+FRJcN180LnKivznOOIqnsJSwb5ZebSav1832S1/E+64K4JoVcfGGYR54Wb2dm1Zrbp3vo1pu0cBon7LGl33ga3WzaeG6mk8zzJHG60kkwFVh0KbVA4OWPPy4zXOXP7PdxY6xpgv4WmaOe4jhuIJtvlSgR7CrBWxh1DbgOSEU8GvWvhj44sbTS2tdY1L7NYfZl8y5nja3jsApI3zb2OApwRMGGAi7gPnevVdT8EWfiXwRZ/ZWWG5ntFltbu1zLC8cuMnI427mVgw6gDsAR+dy41zClSrYfFty53o7bO6b7aW6LbTSzbP02pwpluXZrhsZRhyezulbrFxcVfe7Te+9t3oreL+HtS0+x+J+n6TqEepC6j8PXk8clvZF4P3U9pvWN1+RpSGBMaHcCCAMMN1P9pz9mLWvjZ8ONEsLfizt9Ql1TUgl2DDZsEkWIbSS7OqySjPbzMHg7h3E+myLceEbWZYb+9j1Zlt51b5VVrK8jDNgH7Od2xSdpDYUD5nCD06wtBbK1qHLR3Bmhk8qNWiklfOZmK/dIXzBn7oC9ztJ8CvnOIy/FUcbgmueF3rqr+8rpaW0d9eu+zPXzSNHF0KmDxKvCe61V0td1rrb+rM8zku7n4feGdF8NrpsskjPZ6LbJZxK1vab4ZCXlIZRHCjRHBJJwigKScnC1kab8C9Ct4Ncv5vPu13RyTMIReTtMZJHii3M4JkckKSUGSNwzgdLe+ONH8NbvEGm25uN4/4k9nY2b6hqDeaxlLoIy7Ayl+AYyAq4O3JVem/Zz/Z417xXFfeMtW0/TPDPjK/P7q31Cf7ddWNp8yorSoW2yttYsFZgF2IpwpFLCuFKm6mJfKpO71Scp6vTW6stZPVJtp6uJ0YrHRw8PaTXLBWsrWu9ttbL0v1XmV/hr4N1N9Hhn8RQ22mzsmUtY8MwGBy5xwc5IUAEDG7nKij4z8UWeiReV5keVyDjvWt+0P8ADT4leENJuL62bwncWdnG09zMdW+yrZxKMvJM0ypGiKASSXwBycV+fPxS/a8m1HVbyCG8hvvsxKmezkaS3fHXa+BuGeAw+U9QSCCf1zKMPLNMMqlCfMlvaXM166vX1PyPMMPgniHVkoxUtlFJL5Lsfa1v4/shCu1I2HqaK/OoftPeMLUYWzuCjfMhkidSw7H6e9FfSR4PqNX/AMjzP9lWiZ+jf7I/j7xr4l0iXW/Emi/2TpgQzCZ8u6DAxkAfdxnJFfROk/tEeH9D0eKSa+s5IZDtjlgl3K//ANf2rzb4seOtKn+FWpabYTWN5eNF5EEKz+WRKVJQZHTpmvI49Y0L4faPcSfESLWtD8FaxoitFfJJHdHTdVG0ESBcFYpMybJVOAQCRgnH4nw5n2OzJzqugoR5uVRTs9m9ObdtK1nZX66n6XisDQlDmrN8y8t1ounrf0Pp3xf8YdH8a6DcCNY7y1jXDpKoZH74INfGXxu+FPh/xLa6reaH9q8P7VMk4spHkhl3ZB3xM2COTkKU6+5rqtY8Z3vjfUmP2K8sI57W1s1nhnjjtZ2C7RdPsByrjaSVIwB3ry/wL8Qb3wl8SI9Lv/sbW6Xca31teIZI5I1dTIhwRklcgZ4zjIIyK+hhQVX2uLwNbndLXlX2la/wu+3XTc2oXy+dOjXg4c+id9n2vtr0/I9G/Z28Aah4z8CrI2sajJa2vl28aRWyvAQANmzzF3MqshBI4AGCuPve56J4A1jwQfJskmvtKSGSCLTFZBLACVP7okhMhgxEZKoBt2eXjD2vAfifT/FOlLNoMdp/ZxLzO8ULeXHIz5wfmAxuZhx06YGRXS6VJqWugMtxYtLG+I3eyJYgbQ2VE+eedpODwpI65/KMRnFfEYio6lNxV78rW3m7JO/nudmaYis4Wlay/rp1/QxfHnhqz1/RLHXdOE11aQaja3V1dRq0c0bW91FI0bxsAyuoTBSRQRnBxjFSfFXR7XTReWd5cSfY2uI5NSkkVrhirhdluBHtZFbKM7AkBJACNshKc7+16nxHt/2dPGGqfDmztLzVtN0Wa41LUZrFmtZoI1OY5Y2mCu23zGidstG6qIw6u6HgpPGGvf8ACydPtvEl/wCC/H+oaXO1gq6TfXVvZXV20jGabylR4knLhyQPtDjcAjAFkHtZbwzmmLw0cxw8HKjeWiu2+VLXa1rpptPRp6aM8PBYyEq8aFWok0urSfktbJO/R20aaXQ6X4ifFvwf8ONdOuQpdXOsXlv9mOoG4js7WSzeQPtNy5VZACoKlPMxvcfIpY1xPhf9umLQfD+pLbWtzdTSXBmeTRV/tCQEYCxzSxbhkbQNy7M/N8oJOPcv+GSNHsvCesXFpdan4fvdQmXUbTU7q+kvoNHYCNxtSZ9piDAnARABIACCA1YOnftQ694x0TXtAvtc8E+J5vCtoo1fWrLUXNhC8gPlKZI0YNI4B4VVwVw23kp62T5RgczjOlVkuam1zRlLkai7WfvJxtd2+7q1fsxWeYaklSo0/abXcrvbZJRumvnv958Jf8FCv24NR/ai8KWvwph8J6xYagusLd3lzb6kZIb3yWkEcYt0UmdWykuXf5HjQhWIDjO/Z88MeJP2SBdX+veF9P0uLxZb/wDCPqPEVuYbiSOYEGWG3kCtNGMYLqdoPXPbrfGvjqP4a/GWebS9B0jxj4g0e5Y/ZNNtwPtjMgki3T/JIUbMbJlwSfuIzBlHlfxw+MPijxP8Sdf1j/hG59N1prl1SW5iS51HSoFJMcMQEjxQ7EAXOC/feWZi39KZLksqEI4DCUlTw8YuTak5S5m1trtbVu7WyS3t+aY3EQbdWtJTnKVrctkl0T8/Ky669T6Xv/2lPgv8MobPQ/F1vfxeINPtY47uC60lPNt3xkoRGx2juA+G2sCRggkr5Z0TwWmoaetysl1It1++Hn33zgMARkYQrnO7BUH5s4GcArxZcG8LVJOdSnNye9vbpX62Sdlr0Whv7TMuk4r1lTv+Ov3lj9gH9tvwd8MfiTe+IPG8N54hjvEYPpV8+0IwACsjOShYglccHp2r9N/2rfE/gn4VfBnXtT1iPTbfw3rGji/sLe6VTnMe/wAoLzk85A96KK+Y8QMjw0MdQ9neN5R2sraxjo7Xs02n8j3MnxlWpRVSbu/e762vJaXtuvxZ+R3gf9uixsvjO2qeDY7mz0PUrabTJtEeW4vpY5liMsc0Fkk0Iddy4QNKUD4LRnaFb9A/iF8C/h/4w+BHhX4mab428P6BPqmjW2uHSvGGnf2Pq2q20zNGZQBLuRvNhuEiDo63CxboyV+Ziiv0/NuHcBQlKtShacYWUk2nrpra199L3t958phc8xtVRpzneLlqrJrbzTtslpb77MzfC3jrx5Z/btS+DvgrxJ400GIpYS32m6LHIzyqEkAeCaRLlV5GGKKrHpkrxS+FfxR+JHhX9pjOp6B9ntZrK6u5NP16aw0w2COm8ieczvPAUKxkCSIlkVQSD+8BRXy0uHcueDrQq0oy9pFxk2lzSVrayST9LNWeq1O+WYYiddQ5mktrNr+v8tDzP4/+Pf7b8d3mpeIfEkOpatbuZ9Pi0m+fUbaDlcRo+RbxxL22h+VJKFjurW/ac/a703Xpte8M/DmTSf8AhDbm7F1ZS2/9pQTWYlVZBEyNdGIy2+9oWHleXvWRlGNhBRXu4HA0aOEjRpq0UlZdktLJbJW6bEVJuVXnfS/+d/XTfzZ4BYfHrwn8F/GC+IPidZ6r48bySbXSmvnRr6Qf89nzvMa8HgjkDr0rsfBXxx8aftw+BtY8UeFfg38K9PXT0k062judGu204MI9q7blplBnCeUd6ksGRNy7RglFcHFknlmUfX8N8fPBat2s3qmk0mn1Q41J4ipyzdrJ7f8ABvb5WZT+APw/8YeDvD+oW3iz4iWvwjh1K3ktZrzRfD8+pXl/azRSpK0flOqqoAKZjIl+dicAgV8p+N/gdefDaz1PXLHXtKl0+7Md5HZanffZtRvn25kaBSP3hXcpIL7sswVWIYgor0uGcVN4qEIpRjPmbSWjaSa3v2/Ta1vPz3E1IYpxk+ZKy19F2t3/AF3u3vfDX4667oXhv7O2va5bqJSyQw382yJSB8vBx1z0ooor7upldCpNzle7/rsfLyk7n//Z";
    }
}