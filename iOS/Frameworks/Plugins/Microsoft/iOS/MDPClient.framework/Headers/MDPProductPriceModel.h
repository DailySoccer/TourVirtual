//
//  MDPProductPriceModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPProductPriceModel.h"


#pragma mark - Coin Type
typedef NS_ENUM(NSInteger, MDPProductPriceModelCointype) {
    MDPProductPriceModelCointypeMoney     = 0,
    MDPProductPriceModelCointypePoints    = 1,
};


#pragma mark - Interface
@interface MDPProductPriceModel : _MDPProductPriceModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
