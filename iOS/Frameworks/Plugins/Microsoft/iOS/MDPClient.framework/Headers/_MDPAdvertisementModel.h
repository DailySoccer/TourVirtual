//
//  _MDPAdvertisementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAdvertisementModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAdvertisementModelAttributes {
	__unsafe_unretained NSString *adNavigationType;
	__unsafe_unretained NSString *idAdvertisement;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
} MDPAdvertisementModelAttributes;

extern const struct MDPAdvertisementModelRelationships {
	__unsafe_unretained NSString *languages;
} MDPAdvertisementModelRelationships;

@class MDPAdvertisementLanguageModel;

@interface _MDPAdvertisementModel : NSManagedObject

@property (nonatomic, strong) NSNumber* adNavigationType;

@property (atomic) uint16_t adNavigationTypeValue;
- (uint16_t)adNavigationTypeValue;
- (void)setAdNavigationTypeValue:(uint16_t)value_;

//- (BOOL)validateAdNavigationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAdvertisement;

//- (BOOL)validateIdAdvertisement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *languages;

- (NSMutableSet*)languagesSet;

@end

@interface _MDPAdvertisementModel (LanguagesCoreDataGeneratedAccessors)
- (void)addLanguages:(NSSet*)value_;
- (void)removeLanguages:(NSSet*)value_;
- (void)addLanguagesObject:(MDPAdvertisementLanguageModel*)value_;
- (void)removeLanguagesObject:(MDPAdvertisementLanguageModel*)value_;
@end

@interface _MDPAdvertisementModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAdNavigationType;
- (void)setPrimitiveAdNavigationType:(NSNumber*)value;

- (uint16_t)primitiveAdNavigationTypeValue;
- (void)setPrimitiveAdNavigationTypeValue:(uint16_t)value_;

- (NSString*)primitiveIdAdvertisement;
- (void)setPrimitiveIdAdvertisement:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSMutableSet*)primitiveLanguages;
- (void)setPrimitiveLanguages:(NSMutableSet*)value;

@end
