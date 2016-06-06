//
//  _MDPMenuModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMenuModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMenuModelAttributes {
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *enabledEndDate;
	__unsafe_unretained NSString *enabledStartDate;
	__unsafe_unretained NSString *excludedCountries;
	__unsafe_unretained NSString *filter;
	__unsafe_unretained NSString *frame;
	__unsafe_unretained NSString *idAdvertisement;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idItem;
	__unsafe_unretained NSString *idLevel;
	__unsafe_unretained NSString *idParent;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchStatus;
	__unsafe_unretained NSString *onlyClubMembers;
	__unsafe_unretained NSString *onlyClubPaidFan;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *parameters;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *visible;
} MDPMenuModelAttributes;

extern const struct MDPMenuModelRelationships {
	__unsafe_unretained NSString *advertisements;
	__unsafe_unretained NSString *frameUrl;
	__unsafe_unretained NSString *text;
} MDPMenuModelRelationships;

@class MDPMenuAdvertisementModel;
@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;

@interface _MDPMenuModel : NSManagedObject

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* enabledEndDate;

//- (BOOL)validateEnabledEndDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* enabledStartDate;

//- (BOOL)validateEnabledStartDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* excludedCountries;

//- (BOOL)validateExcludedCountries:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* filter;

//- (BOOL)validateFilter:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* frame;

@property (atomic) BOOL frameValue;
- (BOOL)frameValue;
- (void)setFrameValue:(BOOL)value_;

//- (BOOL)validateFrame:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAdvertisement;

//- (BOOL)validateIdAdvertisement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idItem;

//- (BOOL)validateIdItem:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idLevel;

@property (atomic) uint64_t idLevelValue;
- (uint64_t)idLevelValue;
- (void)setIdLevelValue:(uint64_t)value_;

//- (BOOL)validateIdLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idParent;

//- (BOOL)validateIdParent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* matchStatus;

//- (BOOL)validateMatchStatus:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* onlyClubMembers;

@property (atomic) BOOL onlyClubMembersValue;
- (BOOL)onlyClubMembersValue;
- (void)setOnlyClubMembersValue:(BOOL)value_;

//- (BOOL)validateOnlyClubMembers:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* onlyClubPaidFan;

@property (atomic) BOOL onlyClubPaidFanValue;
- (BOOL)onlyClubPaidFanValue;
- (void)setOnlyClubPaidFanValue:(BOOL)value_;

//- (BOOL)validateOnlyClubPaidFan:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) uint64_t orderValue;
- (uint64_t)orderValue;
- (void)setOrderValue:(uint64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* parameters;

//- (BOOL)validateParameters:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* visible;

@property (atomic) BOOL visibleValue;
- (BOOL)visibleValue;
- (void)setVisibleValue:(BOOL)value_;

//- (BOOL)validateVisible:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *advertisements;

- (NSMutableSet*)advertisementsSet;

@property (nonatomic, strong) NSSet *frameUrl;

- (NSMutableSet*)frameUrlSet;

@property (nonatomic, strong) NSSet *text;

- (NSMutableSet*)textSet;

@end

@interface _MDPMenuModel (AdvertisementsCoreDataGeneratedAccessors)
- (void)addAdvertisements:(NSSet*)value_;
- (void)removeAdvertisements:(NSSet*)value_;
- (void)addAdvertisementsObject:(MDPMenuAdvertisementModel*)value_;
- (void)removeAdvertisementsObject:(MDPMenuAdvertisementModel*)value_;
@end

@interface _MDPMenuModel (FrameUrlCoreDataGeneratedAccessors)
- (void)addFrameUrl:(NSSet*)value_;
- (void)removeFrameUrl:(NSSet*)value_;
- (void)addFrameUrlObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeFrameUrlObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPMenuModel (TextCoreDataGeneratedAccessors)
- (void)addText:(NSSet*)value_;
- (void)removeText:(NSSet*)value_;
- (void)addTextObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTextObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPMenuModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSDate*)primitiveEnabledEndDate;
- (void)setPrimitiveEnabledEndDate:(NSDate*)value;

- (NSDate*)primitiveEnabledStartDate;
- (void)setPrimitiveEnabledStartDate:(NSDate*)value;

- (NSData*)primitiveExcludedCountries;
- (void)setPrimitiveExcludedCountries:(NSData*)value;

- (NSString*)primitiveFilter;
- (void)setPrimitiveFilter:(NSString*)value;

- (NSNumber*)primitiveFrame;
- (void)setPrimitiveFrame:(NSNumber*)value;

- (BOOL)primitiveFrameValue;
- (void)setPrimitiveFrameValue:(BOOL)value_;

- (NSString*)primitiveIdAdvertisement;
- (void)setPrimitiveIdAdvertisement:(NSString*)value;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdItem;
- (void)setPrimitiveIdItem:(NSString*)value;

- (NSNumber*)primitiveIdLevel;
- (void)setPrimitiveIdLevel:(NSNumber*)value;

- (uint64_t)primitiveIdLevelValue;
- (void)setPrimitiveIdLevelValue:(uint64_t)value_;

- (NSString*)primitiveIdParent;
- (void)setPrimitiveIdParent:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitiveMatchStatus;
- (void)setPrimitiveMatchStatus:(NSData*)value;

- (NSNumber*)primitiveOnlyClubMembers;
- (void)setPrimitiveOnlyClubMembers:(NSNumber*)value;

- (BOOL)primitiveOnlyClubMembersValue;
- (void)setPrimitiveOnlyClubMembersValue:(BOOL)value_;

- (NSNumber*)primitiveOnlyClubPaidFan;
- (void)setPrimitiveOnlyClubPaidFan:(NSNumber*)value;

- (BOOL)primitiveOnlyClubPaidFanValue;
- (void)setPrimitiveOnlyClubPaidFanValue:(BOOL)value_;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (uint64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(uint64_t)value_;

- (NSString*)primitiveParameters;
- (void)setPrimitiveParameters:(NSString*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSNumber*)primitiveVisible;
- (void)setPrimitiveVisible:(NSNumber*)value;

- (BOOL)primitiveVisibleValue;
- (void)setPrimitiveVisibleValue:(BOOL)value_;

- (NSMutableSet*)primitiveAdvertisements;
- (void)setPrimitiveAdvertisements:(NSMutableSet*)value;

- (NSMutableSet*)primitiveFrameUrl;
- (void)setPrimitiveFrameUrl:(NSMutableSet*)value;

- (NSMutableSet*)primitiveText;
- (void)setPrimitiveText:(NSMutableSet*)value;

@end
