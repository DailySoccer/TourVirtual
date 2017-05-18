//
//  MDPFanModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanModel.h"

#pragma mark - Gender
typedef NS_ENUM(NSInteger, MDPFanModelGender ) {
    MDPFanModelGenderMale                = 1,
    MDPFanModelGenderFemale              = 2,
} ;

#pragma mark - DocumentType
typedef NS_ENUM(NSInteger, MDPFanModelDocumentType) {
    MDPFanModelDocumentTypeNif           = 0,
    MDPFanModelDocumentTypePassport      = 1,
} ;

#pragma mark - FanCardType
typedef NS_ENUM(NSInteger, MDPFanModelFanCardType ) {
    MDPFanModelFanCardTypePremium        = 0,
    MDPFanModelFanCardTypeSingular       = 1,
} ;

#pragma mark - PreferredSport
typedef NS_ENUM(NSInteger, MDPFanModelPreferredSport) {
    MDPFanModelPreferredSportUnknown        = -1,
    MDPFanModelPreferredSportFootball       = 0,
    MDPFanModelPreferredSportBasketball     = 1,
    MDPFanModelPreferredSportBoth           = 2,
} ;

#pragma mark - Title
typedef NS_ENUM(NSInteger, MDPFanModelTitle) {
    MDPFanModelTitleUnknown             = - 1,
    MDPFanModelTitleMr                  = 0,
    MDPFanModelTitleMss                 = 1,
} ;

#pragma mark - Device Types
typedef NS_ENUM(NSInteger, MDPFanModelDeviceType) {
    MDPAppItemModelDeviceTypePhone   = 0,
    MDPAppItemModelDeviceTypeTablet  = 1,
    MDPAppItemModelDeviceTypePC      = 2,
};

#pragma mark - Fan Types
typedef NS_ENUM(NSInteger, MDPFanModelFanType) {
    MDPFanModelFanTypeUnknown       = -1,
    MDPFanModelFanTypeRegularFan    = 0,
    MDPFanModelFanTypePaidFan       = 1,
    MDPFanModelFanTypeMember        = 2,
};


#pragma mark - Interface
@interface MDPFanModel : _MDPFanModel

+ (MDPFanModel *)fanWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (BOOL)deleteAllExceptFanWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)fanFetchedResultsControllerWithIdUser:(NSString *)idUser
                                                 managedObjectContext:(NSManagedObjectContext *)context
                                                             delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
