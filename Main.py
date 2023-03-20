from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys

def Exec():
    driver = webdriver.Chrome()

    driver.get("https://www.uts.edu.au/")
    driver.maximize_window()

    ContactUs = driver.find_element(By.XPATH, '//*[@id="block-utilitybar"]/nav/ul/li[6]/a')
    ContactUs.click()

    driver.implicitly_wait(2)

    Search = driver.find_element(By.XPATH, '//*[@id="site-search-toggle"]')
    Search.click()

    driver.implicitly_wait(9)

    TextBox = driver.find_element(By.XPATH, '//*[@id="edit-search-keys--2"]')
    TextBox.send_keys("Games Development")
    TextBox.send_keys(Keys.ENTER)

    GameDev = driver.find_element(By.XPATH, '//*[@id="block-mainpagecontent"]/main/ol/li[1]/h3/a')

    assert GameDev.text == "Bachelor of Games Development | University of Technology Sydney"
    GameDev.click()

    ATAR = driver.find_element(By.XPATH, '//*[@id="course-overview"]/div/div/div/div/div/aside/div[1]/div[2]/div/div/p')
    assert ATAR.text == "81.20"

    # assert SecurityAndEmergenciesPN == "Call +61 2 9514 1192"
    #text_box.send_keys("Selenium")
    #submit_button.click()

    #message = driver.find_element(by=By.ID, value="message")
    #value = message.text

    print ("FINISHED")

    driver.quit()

Exec()
