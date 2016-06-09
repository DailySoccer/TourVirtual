//
//  _MDPSubscriptionConfigurationTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubscriptionConfigurationTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubscriptionConfigurationTypeModelAttributes {
	__unsafe_unretained NSString *descriptionSubscriptionConfigurationType;
	__unsafe_unretained NSString *highlight;
	__unsafe_unretained NSString *idType;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPSubscriptionConfigurationTypeModelAttributes;

extern const struct MDPSubscriptionConfigurationTypeModelRelationships {
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pagedSubscriptionConfigurationTypeResults;
} MDPSubscriptionConfigurationTypeModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedSubscriptionConfigurationTypeModel;

@interface _MDPSubscriptionConfigurationTypeModel : NSManagedObject

@property (nonatomic, strong) NSString* descriptionSubscriptionConfigurationType;

//- (BOOL)validateDescriptionSubscriptionConfigurationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highlight;

@property (atomic) BOOL highlightValue;
- (BOOL)highlightValue;
- (void)setHighlightValue:(BOOL)value_;

//- (BOOL)validateHighlight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idType;

//- (BOOL)validateIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *name;

- (NSMutableSet*)nameSet;

@property (nonatomic, strong) MDPPagedSubscriptionConfigurationTypeModel *pagedSubscriptionConfigurationTypeResults;

//- (BOOL)validatePagedSubscriptionConfigurationTypeResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPSubscriptionConfigurationTypeModel (NameCoreDataGeneratedAccessors)
- (void)addName:(NSSet*)value_;
- (void)removeName:(NSSet*)value_;
- (void)addNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDescriptionSubscriptionConfigurationType;
- (void)setPrimitiveDescriptionSubscriptionConfigurationType:(NSString*)value;

- (NSNumber*)primitiveHighlight;
- (void)setPrimitiveHighlight:(NSNumber*)value;

- (BOOL)primitiveHighlightValue;
- (void)setPrimitiveHighlightValue:(BOOL)value_;

- (NSString*)primitiveIdType;
- (void)setPrimitiveIdType:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveName;
- (void)setPrimitiveName:(NSMutableSet*)value;

- (MDPPagedSubscriptionConfigurationTypeModel*)primitivePagedSubscriptionConfigurationTypeResults;
- (void)setPrimitivePagedSubscriptionConfigurationTypeResults:(MDPPagedSubscriptionConfigurationTypeModel*)value;

@end
