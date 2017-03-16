//
//  MDPPaidFanCardInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPaidFanCardInfoModel.h"


#pragma mark - PaidFanCardType
typedef NS_ENUM(NSInteger, MDPPaidFanCardInfoModelPaidFanCardType) {
    MDPPaidFanCardInfoModelPaidFanCardTypeJunior                = 0,
    MDPPaidFanCardInfoModelPaidFanCardTypeSenior                = 1,
    MDPPaidFanCardInfoModelPaidFanCardTypeInternational         = 2,
    MDPPaidFanCardInfoModelPaidFanCardTypePlusTenYears          = 3,
};


#pragma mark - Interface
@interface MDPPaidFanCardInfoModel : _MDPPaidFanCardInfoModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
